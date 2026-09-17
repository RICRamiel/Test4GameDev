public static class EventsProvider
{
    public class OpenScreenEvent
    {
        public readonly string ScreenId;

        public OpenScreenEvent(string screenId)
        {
            ScreenId = screenId;
        }
    }

    public class SceneTransitionEvent
    {
        public readonly string SceneId;

        public SceneTransitionEvent(string sceneId)
        {
            SceneId = sceneId;
        }
    }
}
