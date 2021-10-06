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
        // Current movement direction being commanded by the player
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
            // Listen to move action input events
            InputAction movementAction = _playerInput.actions.FindAction("Movement");
            movementAction.performed    += OnMove;
            movementAction.canceled     += OnMove;

            // Listen to look action input events
            InputAction lookAction = _playerInput.actions.FindAction("Look");
            lookAction.performed += OnLook;
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
            // Stop listening to move action input events
            InputAction movementAction = _playerInput.actions.FindAction("Movement");
            movementAction.performed    -= OnMove;
            movementAction.canceled     -= OnMove;

            // Stop listen to look action input events
            InputAction lookAction = _playerInput.actions.FindAction("Look");
            lookAction.performed += OnLook;
        }

        #endregion

        #region Event Callbacks

        private void OnMove(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Disabled:
                case InputActionPhase.Waiting:
                case InputActionPhase.Canceled:
                    // Player isn't commanding movement
                    _movementDirection = Vector2.zero;
                    break;

                case InputActionPhase.Started:
                case InputActionPhase.Performed:
                    // Player is commanding movement
                    _movementDirection = context.ReadValue<Vector2>();
                    break;

                default:
                    throw new NotImplementedException("InputActionPhase not implemented: " + context.phase.ToString());
            }
        }

        private void OnLook(InputAction.CallbackContext context)
        {
            // Calculate rotation
            Vector2 lookCommand     = context.ReadValue<Vector2>();
            float desiredDegrees    = Vector2.SignedAngle(Vector2.up, lookCommand);

            // Rotate character
            _movement.Rotate(desiredDegrees);
        }

        #endregion
    }
}
