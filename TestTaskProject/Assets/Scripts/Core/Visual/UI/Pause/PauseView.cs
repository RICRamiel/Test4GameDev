using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseView : MonoBehaviour
{
    [SerializeField] private GameObject _root;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _exitButton;

    public Button ContinueButton => _continueButton;
    public Button MainMenuButton => _mainMenuButton;
    public Button ExitButton => _exitButton;

    private void Awake()
    {
        Hide();
    }

    public void Show()
    {
        _root.SetActive(true);
    }

    public void Hide()
    {
        _root.SetActive(false);
    }
}