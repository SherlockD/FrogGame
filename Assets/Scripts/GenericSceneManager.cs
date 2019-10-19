using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenericSceneManager : MonoBehaviour
{
    private void Awake()
    {
        Subscribe();

        DontDestroyOnLoad(this);
    }

    private void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneAsyncCoroutine(sceneName));
    }

    IEnumerator LoadSceneAsyncCoroutine(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void Subscribe()
    {
        MessageBroker.Default
            .Receive<LoadSceneEvent>()
            .Subscribe((loadSceneEvent) =>
            {
                LoadSceneAsync(loadSceneEvent.SceneName);
            });

        MessageBroker.Default
            .Receive<RestartGameEvent>()
            .Subscribe((restartGameEvent) => 
            {
                LoadSceneAsync(SceneManager.GetActiveScene().name);
            });
    }
}
