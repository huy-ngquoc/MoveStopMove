#nullable enable

namespace JoystickPack
{
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(VariableJoystick))]
    public sealed class VariableJoystickEditor : JoystickEditor
    {
        private SerializedProperty? moveThreshold = null;
        private SerializedProperty? joystickType = null;

        protected override void OnJoystickEditorEnable()
        {
            this.moveThreshold = this.serializedObject.FindProperty(nameof(this.moveThreshold));
            this.joystickType = this.serializedObject.FindProperty(nameof(this.joystickType));
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

            backgroundRect.pivot = this.Center;
        }

        protected override void OnJoystickEditorDrawValues()
        {
            EditorGUILayout.PropertyField(this.moveThreshold, new GUIContent("Move Threshold", "The distance away from the center input has to be before the joystick begins to move."));
            EditorGUILayout.PropertyField(this.joystickType, new GUIContent("Joystick Type", "The type of joystick the variable joystick is current using."));
        }
    }
}
