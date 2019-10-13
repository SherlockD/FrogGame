using System;
using UniRx;
using UnityEngine;

public class LoseScreenController : MonoBehaviour
{
    public void OnMainMenuButtonClick()
    {
        MessageBroker.Default
            .Publish(new LoadSceneEvent("MainMenu"));
    }

    public void OnRestartButtonClick()
    {
        MessageBroker.Default
            .Publish(new RestartGameEvent());
    }
}
