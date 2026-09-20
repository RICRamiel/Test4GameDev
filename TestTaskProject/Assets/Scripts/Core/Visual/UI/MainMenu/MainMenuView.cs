using UnityEngine;
using UnityEngine.UI;
using Core.Visual.UI.MainMenu;

public class MainMenuView : ScreenView
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitButton;

    public Button PlayButton => _playButton;
    public Button SettingsButton => _settingsButton;
    public Button ExitButton => _exitButton;

    public override ScreenController Construct(EventManager eventManager)
    {
        return new MainMenuController(this, eventManager);
    }
}