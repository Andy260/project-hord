using UnityEngine;

namespace ProjectHorde
{
    /// <summary>
    /// Describes the behaviour of an object which can be killed or destroyed
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Characters/Health")]
    public class HealthBehaviour : MonoBehaviour
    {
        [Min(0)]
        [SerializeField]
        private int _value;

        #region Properties

        /// <summary>
        /// Current health of this object
        /// </summary>
        public int Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = Mathf.Clamp(value, 0, int.MaxValue);
            }
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Increases the health of this object
        /// </summary>
        /// <param name="value">Amount of health to increase this object by</param>
        public void Heal(int value)
        {
            _value += value;
        }

        /// <summary>
        /// Decreases the health of this object
        /// </summary>
        /// <param name="value">Amount of health to decrease this object by</param>
        public void Damage(int value)
        {
            _value = Mathf.Clamp(_value - value, 0, int.MaxValue);
        }

        #endregion
    }
}
