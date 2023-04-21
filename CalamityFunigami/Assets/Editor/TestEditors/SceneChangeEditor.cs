using UnityEditor;

namespace Calamity.SceneManagement
{
    [CustomEditor(typeof(SceneChange))]
    public class SceneChangeEditor : Editor
    {
        private SerializedProperty _unloadNonStaticScenesProp;
        private SerializedProperty _useSplashScreenProp;
        private SerializedProperty _useCollectionProp;
        private SerializedProperty _sceneToLoadProp;
        private SerializedProperty _sceneCollectionToLoadProp;

        private void OnEnable()
        {
            _unloadNonStaticScenesProp = serializedObject.FindProperty("UnloadNonStaticScenes");
            _useSplashScreenProp = serializedObject.FindProperty("UseSplashScreen");
            _useCollectionProp = serializedObject.FindProperty("UseSceneCollection");
            _sceneToLoadProp = serializedObject.FindProperty("SceneToLoad");
            _sceneCollectionToLoadProp = serializedObject.FindProperty("SceneCollectionToLoad");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_unloadNonStaticScenesProp);
            EditorGUILayout.PropertyField(_useSplashScreenProp);
            EditorGUILayout.PropertyField(_useCollectionProp);

            EditorGUI.BeginChangeCheck();

            if (_useCollectionProp.boolValue)
            {
                EditorGUILayout.PropertyField(_sceneCollectionToLoadProp);

                if (EditorGUI.EndChangeCheck())
                {
                    // If the user changed the value, clear the SceneToLoad property
                    _sceneToLoadProp.objectReferenceValue = null;
                }
            }
            else
            {
                EditorGUILayout.PropertyField(_sceneToLoadProp);

                if (EditorGUI.EndChangeCheck())
                {
                    // If the user changed the value, clear the SceneCollectionToLoad property
                    _sceneCollectionToLoadProp.objectReferenceValue = null;
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}