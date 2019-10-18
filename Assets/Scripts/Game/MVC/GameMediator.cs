using Assets.Scripts.Game;
using Assets.Scripts.Game.MVC;
using System.Collections.Generic;
using UnityEngine;

public class GameMediator : MonoBehaviour
{
    [SerializeField] private GameView _gameView;

    private GameModel _gameModel;
    private GameController _gameController;

    private void Awake()
    {
        Initialize();
        Mediate();

        _gameView.Initialize();

        _gameModel.LoadLevel(0);
    }

    private void Initialize()
    {
        _gameModel = new GameModel();
        _gameController = new GameController();
    }

    private void Mediate()
    {
        _gameController.SetModel(_gameModel);
        _gameView.SetController(_gameController);
        _gameView.SetModel(_gameModel);
    }
}
