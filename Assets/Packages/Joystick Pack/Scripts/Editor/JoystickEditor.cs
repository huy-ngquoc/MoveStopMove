#nullable enable

namespace JoystickPack
{
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(Joystick), true)]
    public class JoystickEditor : Editor
    {
        private SerializedProperty? handleRange = null;
        private SerializedProperty? deadZone = null;
        private SerializedProperty? currentAxisOptions = null;
        private SerializedProperty? snapX = null;
        private SerializedProperty? snapY = null;
        private SerializedProperty? background = null;
        private SerializedProperty? handle = null;

        private Vector2 center = new(0.5F, 0.5F);

        protected SerializedProperty? Background => this.background;

        protected Vector2 Center => this.center;

        public sealed override void OnInspectorGUI()
        {
            this.serializedObject.Update();

            this.DrawValues();
            EditorGUILayout.Space();
            this.DrawComponents();

            this.serializedObject.ApplyModifiedProperties();

            if (this.handle == null)
            {
                this.OnJoystickEditorInspectorGUI();
                return;
            }

            if (this.handle.objectReferenceValue is not RectTransform handleRect)
            {
                this.OnJoystickEditorInspectorGUI();
                return;
            }

            handleRect.anchorMax = this.center;
            handleRect.anchorMin = this.center;
            handleRect.pivot = this.center;
            handleRect.anchoredPosition = Vector2.zero;

            this.OnJoystickEditorInspectorGUI();
        }

        protected virtual void OnJoystickEditorInspectorGUI()
        {
        }

        protected void DrawValues()
        {
            EditorGUILayout.PropertyField(this.handleRange, new GUIContent("Handle Range", "The distance the visual handle can move from the center of the joystick."));
            EditorGUILayout.PropertyField(this.deadZone, new GUIContent("Dead Zone", "The distance away from the center input has to be before registering."));
            EditorGUILayout.PropertyField(this.currentAxisOptions, new GUIContent("Axis Options", "Which axes the joystick uses."));
            EditorGUILayout.PropertyField(this.snapX, new GUIContent("Snap X", "Snap the horizontal input to a whole value."));
            EditorGUILayout.PropertyField(this.snapY, new GUIContent("Snap Y", "Snap the vertical input to a whole value."));

            this.OnJoystickEditorDrawValues();
        }

        protected virtual void OnJoystickEditorDrawValues()
        {
        }

        protected void DrawComponents()
        {
            EditorGUILayout.ObjectField(this.background, new GUIContent("Background", "The background's RectTransform component."));
            EditorGUILayout.ObjectField(this.handle, new GUIContent("Handle", "The handle's RectTransform component."));

            this.OnJoystickEditorDrawComponents();
        }

        protected virtual void OnJoystickEditorDrawComponents()
        {
        }

        protected void OnEnable()
        {
            this.handleRange = this.serializedObject.FindProperty(nameof(this.handleRange));
            this.deadZone = this.serializedObject.FindProperty(nameof(this.deadZone));
            this.currentAxisOptions = this.serializedObject.FindProperty(nameof(this.currentAxisOptions));
            this.snapX = this.serializedObject.FindProperty(nameof(this.snapX));
            this.snapY = this.serializedObject.FindProperty(nameof(this.snapY));
            this.background = this.serializedObject.FindProperty(nameof(this.background));
            this.handle = this.serializedObject.FindProperty(nameof(this.handle));

            this.OnJoystickEditorEnable();
        }

        protected virtual void OnJoystickEditorEnable()
        {
        }
    }
}
