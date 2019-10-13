using UniRx;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void OnMainMenuStartButtonClick()
    {
        Debug.Log("LoadGameScene");
        GameManager.SetSaveLevel();

        MessageBroker.Default
            .Publish(new LoadSceneEvent("GameScene"));
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
