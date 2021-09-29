using UnityEngine;

namespace ProjectHorde.Characters
{
    /// <summary>
    /// Describes a character within the world
    /// </summary>
    [CreateAssetMenu(fileName = "Character", menuName = "Character", order = 0)]
    public class Character : ScriptableObject
    {
        [SerializeField]
        private GameObject _prefab;
        [SerializeField]
        private int _maxHealth;
        [SerializeField]
        private float _movementSpeed;

        #region Properties

        /// <summary>
        /// Prefab of this character type
        /// </summary>
        public GameObject Prefab
        {
            get
            {
                return _prefab;
            }
        }

        /// <summary>
        /// Maximum health this character type will be allowed to have
        /// </summary>
        public int MaxHealth
        {
            get
            {
                return _maxHealth;
            }
        }

        /// <summary>
        /// Movement speed in meters/s for this character type
        /// </summary>
        public float MovementSpeed
        {
            get
            {
                return _movementSpeed;
            }
        }

        #endregion
    }
}
