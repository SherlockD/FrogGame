using Assets.Scripts.Game;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameLevel> _levels;

    private static GameManager _instance;

    public static int LevelsCount => _instance._levels.Count;
    public static bool IsLastLevel => _instance._currentLevelIndex == LevelsCount - 1;

    private int _currentLevelIndex = 0;

    private const string LAST_LEVEL_KEY = "last_level_key";

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (_instance == null)
            _instance = this;
    }

    public static void SetCurrentLevel(int index)
    {
        _instance._currentLevelIndex = index;
    }

    public static GameLevel GetCurrentLevel()
    {
        if (_instance._currentLevelIndex >= _instance._levels.Count)
            return null;

        PlayerPrefs.SetInt(LAST_LEVEL_KEY, _instance._currentLevelIndex);

        return _instance._levels[_instance._currentLevelIndex];
    }

    public static void SetSaveLevel()
    {
        int index = PlayerPrefs.GetInt(LAST_LEVEL_KEY, 0);

        if (index >= _instance._levels.Count)
            return;

        _instance._currentLevelIndex = index;
    }

    public static void SetIndexToNextLevel()
    {
        if (_instance._currentLevelIndex + 1 >= _instance._levels.Count)
            return;

        _instance._currentLevelIndex++;

        PlayerPrefs.SetInt(LAST_LEVEL_KEY, _instance._currentLevelIndex);
    }
}
