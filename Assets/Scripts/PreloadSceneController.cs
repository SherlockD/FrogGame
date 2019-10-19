using UniRx;
using UnityEngine;

public class PreloadSceneController : MonoBehaviour
{
    void Start()
    {
        MessageBroker.Default
            .Publish(new LoadSceneEvent("MainMenu"));
    }
}
