using Assets.Scripts.Game;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameLevel> _levels;

    private static GameManager _instance;

    private int _currentLevelIndex;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (_instance == null)
            _instance = this;
    }

    public static GameLevel GetLevel(int index)
    {
        if (index >= _instance._levels.Count)
            return null;

        return _instance._levels[index];
    }
}
