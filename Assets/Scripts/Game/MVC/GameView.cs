using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Game.MVC
{
    class GameView : MonoBehaviour
    {
        [Header("Containers")]
        [SerializeField] private Transform _horizontalCellsGroup;
        [SerializeField] private Transform _frogsContainer;

        [Header("Prefabs")]
        [SerializeField] private FrogController _frogControllerPrefab;
        [SerializeField] private CellController _cellPrefab;

        [Header("Screens")]
        [SerializeField] private LoseScreenController _loseScreenController;

        private GameModel _gameModel;
        private GameController _gameController;

        private List<CellController> _spawnedCells = new List<CellController>();

        public void SetController(GameController gameController)
        {
            _gameController = gameController;
        }

        public void SetModel(GameModel gameModel)
        {
            _gameModel = gameModel;
        }

        public void Initialize()
        {
            _gameModel.OnDrawLevel += DrawLevel;
            _gameModel.OnMoveToFrom += MoveFromTo;
            _gameModel.OnShakeCell += ShakeCell;
            _gameModel.OnShowWinScreen += ShowWinScreen;
            _gameModel.OnShowLoseScreen += ShowLoseScreen;

            _loseScreenController.OnRestartGameClickCallback += () => new RestartGameEvent().PublishSelf();
        }

        private void DrawLevel(List<int> levelData)
        {
            levelData.ForEach((level) => 
            {
                CellController newCell = Instantiate(_cellPrefab, _horizontalCellsGroup);
                newCell.OnPointerClockCallback += OnCellClick;
                _spawnedCells.Add(newCell);

                if (level == GameModel.EMPTY)
                    return;

                FrogController newFrog = Instantiate(_frogControllerPrefab, newCell.transform);
                newFrog.RectTransform.anchoredPosition = new Vector2(0, newFrog.RectTransform.sizeDelta.y / 3);                
                newFrog.Initialize(level);

                newCell.FrogController = newFrog;
            });
        }

        private void ShakeCell(int cellIndex)
        {
            DOTween.KillAll();
            _spawnedCells[cellIndex].transform.DOShakePosition(0.5f, 4, 10, 100).OnComplete(()=>
            {
                _gameController.WasWrongStep();
            });
        }

        private void MoveFromTo(int fromIndex, int toIndex)
        {
            DOTween.KillAll();

            CellController fromCell = _spawnedCells[fromIndex];
            CellController toCell = _spawnedCells[toIndex];

            FrogController chosenFrog = fromCell.FrogController;

            toCell.FrogController = chosenFrog;
            fromCell.FrogController = null;

            chosenFrog.transform.parent = toCell.transform;
            chosenFrog.transform.DOLocalJump(new Vector2(0, 0), 30 * Mathf.Abs(toIndex - fromIndex), 1, 0.5f).OnComplete(()=> 
            {
                _gameController.MoveCurrentStateCells(fromIndex, toIndex);
            });
        }

        private void OnCellClick(CellController clickedCellController)
        {
            _gameController.MakeStep(_spawnedCells.IndexOf(clickedCellController));
        }

        private void ShowWinScreen()
        {
            Debug.LogError("WIN!");
        }

        private void ShowLoseScreen()
        {
            Debug.LogError("LOSE!");
        }
    }
}
