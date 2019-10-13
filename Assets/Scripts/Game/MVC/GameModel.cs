using System;
using System.Collections.Generic;

namespace Assets.Scripts.Game.MVC
{
    class GameModel
    {
        public const int MALE_FROG = 1;
        public const int FEMALE_FROG = 2;
        public const int EMPTY = 0;

        private List<int> _currentState;
        private bool _canStep;

        public event Action<List<int>> OnDrawLevel;
        public event Action<int> OnShakeCell;
        public event Action<int, int> OnMoveToFrom;

        public event Action OnShowWinScreen;
        public event Action OnShowLoseScreen;

        public GameModel()
        {
            _canStep = true;
        }

        public void LoadLevel()
        {
            GameLevel gameLevel = GameManager.GetCurrentLevel();

            _currentState = gameLevel.GetLevelData();

            OnDrawLevel?.Invoke(_currentState);
        }

        public void SetCanStep(bool canStep)
        {
            _canStep = canStep;
        }

        public void Step(int chosenCellIndex)
        {
            if (chosenCellIndex >= _currentState.Count || chosenCellIndex < 0 || !_canStep)
                return;

            int chosenType = _currentState[chosenCellIndex];
            switch (chosenType)
            {
                case MALE_FROG:
                    if(chosenCellIndex + 1 >= _currentState.Count)
                    {
                        OnShakeCell?.Invoke(chosenCellIndex);
                        return;
                    }
                    if(_currentState[chosenCellIndex + 1] == EMPTY)
                    {
                        OnMoveToFrom?.Invoke(chosenCellIndex, chosenCellIndex + 1);
                        return;
                    }

                    if (chosenCellIndex + 2 >= _currentState.Count)
                    {
                        OnShakeCell?.Invoke(chosenCellIndex);
                        return;
                    }
                    if (_currentState[chosenCellIndex + 1] == FEMALE_FROG && _currentState[chosenCellIndex + 2] == EMPTY)
                    {
                        OnMoveToFrom?.Invoke(chosenCellIndex, chosenCellIndex + 2);
                    }
                    else
                    {
                        OnShakeCell?.Invoke(chosenCellIndex);
                    }
                    break;

                case FEMALE_FROG:
                    if (chosenCellIndex - 1 < 0)
                    {
                        OnShakeCell?.Invoke(chosenCellIndex);
                        return;
                    }
                    if (_currentState[chosenCellIndex - 1] == EMPTY)
                    {
                        OnMoveToFrom?.Invoke(chosenCellIndex, chosenCellIndex - 1);
                        return;
                    }

                    if (chosenCellIndex - 2 < 0)
                    {
                        OnShakeCell?.Invoke(chosenCellIndex);
                        return;
                    }
                    if (_currentState[chosenCellIndex - 1] == MALE_FROG && _currentState[chosenCellIndex - 2] == EMPTY)
                    {
                        OnMoveToFrom?.Invoke(chosenCellIndex, chosenCellIndex - 2);
                    }
                    else
                    {
                        OnShakeCell?.Invoke(chosenCellIndex);
                    }
                    break;
                default:
                    OnShakeCell?.Invoke(chosenCellIndex);
                    return;
            }
        }

        public void MoveCurrentStateCells(int from, int to)
        {
            int buffer = _currentState[from];

            _currentState[from] = _currentState[to];
            _currentState[to] = buffer;

            if (CheckToWin())
            {
                OnShowWinScreen?.Invoke();
                return;
            }

            if (CheckToLoose())
                OnShowLoseScreen?.Invoke();
        }

        private bool CheckToWin()
        {
            int femalesCount = _currentState.FindAll((frog) => frog == FEMALE_FROG).Count;

            int findedFemalesCount = 0;

            foreach(var frog in _currentState)
            {
                if (frog == MALE_FROG)
                    return false;

                if(frog == FEMALE_FROG)
                {
                    findedFemalesCount++;

                    if (findedFemalesCount == femalesCount)
                        return true;
                }
            }

            return false;
        }

        private bool CheckToLoose()
        {
            for(int i = 0; i < _currentState.Count; i++)
            {
                int chosenType = _currentState[i];
                switch (chosenType)
                {
                    case MALE_FROG:             
                        if (i + 1 >= _currentState.Count)
                            continue;

                        if (_currentState[i + 1] == EMPTY)
                            return false;

                        if (i + 2 >= _currentState.Count)
                            continue;

                        if (_currentState[i + 1] == FEMALE_FROG && _currentState[i + 2] == EMPTY)
                            return false;

                        break;
                    case FEMALE_FROG:
                        if (i - 1 < 0)
                            continue;

                        if (_currentState[i - 1] == EMPTY)
                            return false;

                        if (i - 2 < 0)
                            continue;

                        if (_currentState[i - 1] == MALE_FROG && _currentState[i - 2] == EMPTY)
                            return false;

                        break;
                    default:
                        continue;
                }
            }

            return true;
        }
    }
}
