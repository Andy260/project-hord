using UnityEngine;

namespace ProjectHorde.Characters
{
    /// <summary>
    /// Defines the behaviour of a <see cref="Characters.Character"/> within the world
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CharacterMovement), typeof(HealthBehaviour))]
    [AddComponentMenu("Characters/Character")]
    public class CharacterBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Character _type;

        // References
        private HealthBehaviour _health;
        private CharacterMovement _movement;

        #region Properties

        /// <summary>
        /// The type of <see cref="Character"/> this behaviour will be based upon
        /// </summary>
        public Character Type
        {
            get
            {
                return _type;
            }
        }

        #endregion

        #region Unity Event Functions

        private void Awake()
        {
            // Get dependency references
            _health     = GetComponent<HealthBehaviour>();
            _movement   = GetComponent<CharacterMovement>();
        }

        private void Start()
        {
            // Initialise health
            _health.Value = _type.MaxHealth;
            // Initialise movement speed
            _movement.MovementSpeed = _type.MovementSpeed;
        }

        #endregion
    }
}
