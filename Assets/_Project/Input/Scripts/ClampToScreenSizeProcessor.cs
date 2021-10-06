#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectHorde
{
    /// <summary>
    /// Clamps the value within the <see cref="Screen.width"/> 
    /// and <see cref="Screen.height"/> values
    /// </summary>
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    public class ClampToScreenSizeProcessor : InputProcessor<Vector2>
    {
        #region Initialisation

#if UNITY_EDITOR
        static ClampToScreenSizeProcessor()
        {
            Initialise();
        }
#endif

        private static void Initialise()
        {
            InputSystem.RegisterProcessor<ClampToScreenSizeProcessor>();
        }

        #endregion

        #region Overridden Functions

        public override Vector2 Process(Vector2 value, InputControl control)
        {
            return new Vector2(
                Mathf.Clamp(value.x, 0, Screen.width), 
                Mathf.Clamp(value.y, 0, Screen.height));
        }

        #endregion
    }
}
