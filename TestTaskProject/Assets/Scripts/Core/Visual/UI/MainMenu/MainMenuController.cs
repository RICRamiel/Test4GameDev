using UnityEngine;


namespace Core.Visual.UI.MainMenu
{
    public class MainMenuController : ScreenController
    {
        private readonly MainMenuView _view;

        public MainMenuController(
            MainMenuView view,
            EventManager eventManager)
            : base(view, eventManager)
        {
            _view = view;

            _view.PlayButton.onClick.AddListener(Play);
            _view.SettingsButton.onClick.AddListener(OpenSettings);
            _view.ExitButton.onClick.AddListener(Exit);
        }

        private void Play()
        {
            _eventManager.Publish(
                new EventsProvider.SceneTransitionEvent("FirstScene")
            );
        }

        private void OpenSettings()
        {
            _eventManager.Publish(
                new EventsProvider.OpenScreenEvent("Settings")
            );
        }

        private void Exit()
        {
            Debug.Log("Exit game");
        }

        public override void Dispose()
        {
            _view.PlayButton.onClick.RemoveListener(Play);
            _view.SettingsButton.onClick.RemoveListener(OpenSettings);
            _view.ExitButton.onClick.RemoveListener(Exit);

            base.Dispose();
        }
    }
}