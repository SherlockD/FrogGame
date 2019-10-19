using UniRx;
using UnityEngine;

public enum MainMenuState
{
    MainMenuButtonsState,
    MainMenulevelsState
}

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuButtons;
    [SerializeField] private GameObject _levelsPanel;

    private GameObject _currentState;

    private void Awake()
    {
        SwitchState(MainMenuState.MainMenuButtonsState);
    }

    public void OnMainMenuStartButtonClick()
    {
        GameManager.SetSaveLevel();

        MessageBroker.Default
            .Publish(new LoadSceneEvent("GameScene"));
    }

    public void ShowMainMenuButtons()
    {
        SwitchState(MainMenuState.MainMenuButtonsState);
    }

    public void ShowLevelsPanel()
    {
        SwitchState(MainMenuState.MainMenulevelsState);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void SwitchState(MainMenuState state)
    {
        _currentState?.SetActive(false);

        switch (state)
        {
            case MainMenuState.MainMenuButtonsState:
                _currentState = _mainMenuButtons;
                break;
            case MainMenuState.MainMenulevelsState:
                _currentState = _levelsPanel;
                break;
        }

        _currentState?.SetActive(true);
    }
}
