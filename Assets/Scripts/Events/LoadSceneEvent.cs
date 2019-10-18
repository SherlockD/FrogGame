public class LoadSceneEvent : AbstractSelfPublisher
{
    public readonly string SceneName;

    public LoadSceneEvent(string sceneName)
    {
        SceneName = sceneName;
    }
}
