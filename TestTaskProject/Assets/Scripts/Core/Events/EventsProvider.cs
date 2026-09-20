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

    public class CollectibleCollectedEvent
    {
        public readonly string CollectibleId;

        public CollectibleCollectedEvent(string collectibleId)
        {
            CollectibleId = collectibleId;
        }
    }

    public class FirstFloorProgressChangedEvent
    {
        public readonly int Collected;
        public readonly int Required;

        public FirstFloorProgressChangedEvent(int collected, int required)
        {
            Collected = collected;
            Required = required;
        }
    }
}