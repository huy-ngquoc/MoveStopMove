#nullable enable

namespace JoystickPack
{
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(DynamicJoystick))]
    public sealed class DynamicJoystickEditor : JoystickEditor
    {
        private SerializedProperty? moveThreshold = null;

        protected override void OnJoystickEditorEnable()
        {
            this.moveThreshold = this.serializedObject.FindProperty(nameof(this.moveThreshold));
        }

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

        protected override void OnJoystickEditorDrawValues()
        {
            EditorGUILayout.PropertyField(this.moveThreshold, new GUIContent("Move Threshold", "The distance away from the center input has to be before the joystick begins to move."));
        }
    }
}
