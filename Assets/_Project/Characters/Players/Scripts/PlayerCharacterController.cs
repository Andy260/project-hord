using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectHorde.Characters.Players
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CharacterMovement), typeof(PlayerInput))]
    [AddComponentMenu("Characters/Player Character Controller")]
    public class PlayerCharacterController : MonoBehaviour
    {
        private Vector2 _movementDirection;

        // Dependency references
        private CharacterMovement _movement;
        private PlayerInput _playerInput;

        #region Unity Event Functions

        private void Awake()
        {
            // Get component dependencies
            _movement       = GetComponent<CharacterMovement>();
            _playerInput    = GetComponent<PlayerInput>();
        }

        private void OnEnable()
        {
            // Listen to input events
            _playerInput.onActionTriggered += OnActionTriggered;
        }

        private void Update()
        {
            // Move character when there's input
            if (_movementDirection != Vector2.zero)
            {
                _movement.Move(_movementDirection);
            }
        }

        private void OnDisable()
        {
            // Stop listening to input events
            _playerInput.onActionTriggered -= OnActionTriggered;
        }

        #endregion

        #region Event Callbacks

        private void OnActionTriggered(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Canceled:
                case InputActionPhase.Disabled:
                case InputActionPhase.Waiting:
                    // Player isn't commanding movement
                    _movementDirection = Vector2.zero;
                    break;

                case InputActionPhase.Started:
                case InputActionPhase.Performed:
                    // Player is commanding movement
                    _movementDirection = context.ReadValue<Vector2>();

                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        #endregion
    }
}
