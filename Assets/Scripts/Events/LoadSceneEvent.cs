public readonly struct LoadSceneEvent
{
    public readonly string SceneName;

    public LoadSceneEvent(string sceneName)
    {
        SceneName = sceneName;
    }
}
