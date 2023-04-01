using UnityEngine;
using UnityEditor;
using UnityEngine.Audio;

namespace Calamity.Audio
{
	[CustomEditor(typeof(SimpleAudioEvent), true)]
	public class SimpleAudioEventEditor : Editor
	{
		[SerializeField] private AudioSource _previewer;

		public void OnEnable()
		{
			_previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio Events preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
		}

		public void OnDisable()
		{
			DestroyImmediate(_previewer.gameObject);
		}

		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);

			_previewer.outputAudioMixerGroup = (AudioMixerGroup)EditorGUILayout.ObjectField("Mixer (preview only)", _previewer.outputAudioMixerGroup, typeof(AudioMixerGroup), false);

			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Preview"))
			{
				((AudioEvent)target).Play(_previewer);
			}
			if (GUILayout.Button("Stop"))
			{
				_previewer.Stop();
			}
			GUILayout.EndHorizontal();

			EditorGUI.EndDisabledGroup();
		}
	}

	[CustomEditor(typeof(AudioEvent), true)]
	public class AudioEventEditor : Editor
	{
		[SerializeField] private AudioSource _previewer;

		public void OnEnable()
		{
			_previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
		}

		public void OnDisable()
		{
			DestroyImmediate(_previewer.gameObject);
		}

		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);

			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Preview"))
			{
				((AudioEvent)target).Play(_previewer);
			}
			if (GUILayout.Button("Stop"))
			{
				_previewer.Stop();
			}
			GUILayout.EndHorizontal();
			EditorGUI.EndDisabledGroup();
		}
	}

}