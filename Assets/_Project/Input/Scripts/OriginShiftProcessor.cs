#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectHorde.Input
{
    /// <summary>
    /// Offsets the output by a specified amount
    /// </summary>
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    public class OffsetProcessor : InputProcessor<Vector2>
    {
        /// <summary>
        /// Amount to offset the output on the X axis
        /// </summary>
        public float xOffset;

        /// <summary>
        /// Amount to offset the output on the Y axis
        /// </summary>
        public float yOffset;

        #region Initialisation

#if UNITY_EDITOR
        static OffsetProcessor()
        {
            Initialise();
        }
#endif

        private static void Initialise()
        {
            InputSystem.RegisterProcessor<OffsetProcessor>();
        }

        #endregion

        #region Overridden Functions

        public override Vector2 Process(Vector2 value, InputControl control)
        {
            return value + new Vector2(xOffset, yOffset);
        }

        #endregion
    }
}
