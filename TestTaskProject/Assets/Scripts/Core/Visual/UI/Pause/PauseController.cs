using UnityEngine;
using static EventsProvider;

public class PauseController
{
    private readonly PauseView _view;
    private readonly EventManager _eventManager;

    private bool _isOpen;

    public PauseController(PauseView view, EventManager eventManager)
    {
        _view = view;
        _eventManager = eventManager;

        _view.ContinueButton.onClick.AddListener(Continue);
        _view.MainMenuButton.onClick.AddListener(GoToMainMenu);
        _view.ExitButton.onClick.AddListener(Exit);
    }

    public void Open()
    {
        if (_isOpen)
        {
            return;
        }

        _isOpen = true;

        Time.timeScale = 0f;
        _view.Show();
    }

    public void Close()
    {
        if (!_isOpen)
        {
            return;
        }

        _isOpen = false;

        Time.timeScale = 1f;
        _view.Hide();
    }

    public void Toggle()
    {
        if (_isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    private void Continue()
    {
        Close();
    }

    private void GoToMainMenu()
    {
        Close();

        _eventManager.Publish(
            new SceneTransitionEvent("MainMenuScene")
        );
    }

    private void Exit()
    {
        Application.Quit();
    }

    public void Dispose()
    {
        _view.ContinueButton.onClick.RemoveListener(Continue);
        _view.MainMenuButton.onClick.RemoveListener(GoToMainMenu);
        _view.ExitButton.onClick.RemoveListener(Exit);

        Time.timeScale = 1f;
    }
}