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
}
