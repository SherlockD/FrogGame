using UniRx;
using UnityEngine;

public class WinScreenController : BaseGameScreenPanel
{
    [SerializeField] private GameObject _nextLevelButton;

    public bool SetActive
    {
        set => gameObject.SetActive(value);
    }

    private void OnEnable()
    {
        if (GameManager.IsLastLevel)
            _nextLevelButton.SetActive(false);
    }

    public void NextLevelButtonClick()
    {
        GameManager.SetIndexToNextLevel();

        MessageBroker.Default
            .Publish(new RestartGameEvent());
    }
}
