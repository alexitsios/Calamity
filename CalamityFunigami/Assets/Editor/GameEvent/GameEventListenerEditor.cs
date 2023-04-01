using UnityEditor;
using UnityEngine;

namespace Calamity.EventSystem
{
    [CustomEditor(typeof(GameEventListener))]
    public class GameEventListenerEditor : Editor
    {
        private SerializedProperty _gameEventProp;
        private SerializedProperty _callbackEventProp;
        private SerializedProperty _developerNotesProp;
        private GUIStyle _boldLabelStyle;
        private bool _showCallbackEvents = false;

        private void OnEnable()
        {
            _gameEventProp = serializedObject.FindProperty("TargetGameEvent");
            _callbackEventProp = serializedObject.FindProperty("CallbackEvent");
            _developerNotesProp = serializedObject.FindProperty("_developerNotes");
            _boldLabelStyle = new GUIStyle(EditorStyles.boldLabel);
            _boldLabelStyle.richText = true;
        }

        /// <summary>
        /// Override of the default inspector GUI for GameEventListener.
        /// </summary>
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_gameEventProp);

            if (_gameEventProp.objectReferenceValue == null)
            {
                serializedObject.ApplyModifiedProperties();
                return;
            }

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("<b>" + _gameEventProp.objectReferenceValue?.name.ToString() + " Event</b>", _boldLabelStyle);

            EditorGUILayout.Space();

            _showCallbackEvents = EditorGUILayout.BeginFoldoutHeaderGroup(_showCallbackEvents, "Callback Events");

            if (_showCallbackEvents)
            {
                EditorGUI.indentLevel++;

                EditorGUILayout.PropertyField(_callbackEventProp);

                EditorGUI.indentLevel--;
            }

            EditorGUILayout.EndFoldoutHeaderGroup();

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(_developerNotesProp, true);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
