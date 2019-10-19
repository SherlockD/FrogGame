using UniRx;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private LevelButton _levelButtonPrefab;

    [Header("Components")]
    [SerializeField] private Transform _levelHorisontalGroup;

    private void Awake()
    {
        for(int i = 0; i < GameManager.LevelsCount; i++)
        {
            LevelButton newButton = Instantiate(_levelButtonPrefab, _levelHorisontalGroup);

            newButton.Initialize($"Level {i + 1}", i);
        }
    }
}
