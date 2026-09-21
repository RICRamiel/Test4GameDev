using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Gameplay
{
    public class PauseInputHandler : MonoBehaviour
    {
        private PauseController _pauseController;
        private PlayerInputActions _inputActions;

        [Inject]
        public void Construct(PauseController pauseController)
        {
            _pauseController = pauseController;
            _inputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _inputActions.UI.Pause.performed += OnPausePerformed;
            _inputActions.UI.Enable();
        }

        private void OnDisable()
        {
            _inputActions.UI.Pause.performed -= OnPausePerformed;
            _inputActions.UI.Disable();
        }

        private void OnPausePerformed(InputAction.CallbackContext context)
        {
            _pauseController.Toggle();
        }
    }
}