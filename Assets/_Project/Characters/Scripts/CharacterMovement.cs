using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectHorde
{
    /// <summary>
    /// Provides other components an interface for moving this <see cref="Characters.Character"/>
    /// </summary>
    [AddComponentMenu("Character/Character Movement")]
    [RequireComponent(typeof(CharacterController))]
    [DisallowMultipleComponent]
    public class CharacterMovement : MonoBehaviour
    {
        [Min(0)]
        [SerializeField]
        private float _speed;

        // Current movement velocity
        private Vector3 _velocity;

        // References to dependencies
        private CharacterController _characterController;

        #region Properties

        /// <summary>
        /// Speed in meters/s
        /// </summary>
        public float MovementSpeed
        {
            get
            {
                return _speed;
            }

            set
            {
                _speed = Mathf.Clamp(value, 0, int.MaxValue);
            }
        }

        #endregion

        #region Unity Event Functions

        private void Awake()
        {
            // Get dependencies
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            // Move the character
            CollisionFlags collisionFlags = _characterController.Move((_velocity * _speed) * Time.deltaTime);

            // Null velocity
            _velocity = Vector3.zero;
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Moves the character
        /// </summary>
        /// <param name="direction">Normalised direction</param>
        public void Move(Vector2 direction)
        {
            // Add desired direction to velocity
            _velocity += new Vector3(direction.x, 0, direction.y);
        }

        /// <summary>
        /// Moves the character based upon an <see cref="InputAction"/>
        /// </summary>
        /// <param name="context"><see cref="InputAction"/> context</param>
        public void Move(InputAction.CallbackContext context)
        {
            Move(context.ReadValue<Vector2>());
        }

        /// <summary>
        /// Rotates the character
        /// </summary>
        /// <param name="angle">Degrees to rotate the character by</param>
        public void Rotate(float angle)
        {
            transform.Rotate(Vector3.up, angle);
        }

        #endregion
    }
}
