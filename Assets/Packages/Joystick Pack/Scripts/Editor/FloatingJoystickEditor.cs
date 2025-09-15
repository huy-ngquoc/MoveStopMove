#nullable enable

namespace JoystickPack
{
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(FloatingJoystick))]
    public class FloatingJoystickEditor : JoystickEditor
    {
        protected override void OnJoystickEditorInspectorGUI()
        {
            if (this.Background == null)
            {
                return;
            }

            if (this.Background.objectReferenceValue is not RectTransform backgroundRect)
            {
                return;
            }

            backgroundRect.anchorMax = Vector2.zero;
            backgroundRect.anchorMin = Vector2.zero;
            backgroundRect.pivot = this.Center;
        }
    }
}
