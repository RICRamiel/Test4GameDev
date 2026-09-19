using UnityEngine;

namespace Gameplay
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;

        private Rigidbody _rigidbody;
        private PlayerInputActions _inputActions;

        private Vector2 _moveInput;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _inputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _inputActions.Player.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Player.Disable();
        }

        private void Update()
        {
            _moveInput = _inputActions.Player.Move.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            Vector3 movement = new Vector3(
                _moveInput.x,
                0f,
                _moveInput.y
            );

            Vector3 nextPosition =
                _rigidbody.position +
                movement * _speed * Time.fixedDeltaTime;

            _rigidbody.MovePosition(nextPosition);
        }
    }
}