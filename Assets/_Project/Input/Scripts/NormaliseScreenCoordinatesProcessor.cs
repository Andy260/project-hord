#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectHorde.Input
{
    /// <summary>
    /// Normalises the given input within the screen size
    /// </summary>
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    public class NormaliseScreenCoordinatesProcessor : InputProcessor<Vector2>
    {
        #region Initialisation

#if UNITY_EDITOR
        static NormaliseScreenCoordinatesProcessor()
        {
            Initialise();
        }
#endif

        private static void Initialise()
        {
            InputSystem.RegisterProcessor<NormaliseScreenCoordinatesProcessor>();
        }

        #endregion

        #region Overridden Functions

        public override Vector2 Process(Vector2 value, InputControl control)
        {
            return new Vector2(value.x < 1 ? 0f : value.x / Screen.width, 
                value.y < 1 ? 0f : value.y / Screen.height);
        }

        #endregion
    }
}
