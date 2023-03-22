using UnityEngine;
using UnityEditor;

namespace Calamity.Audio
{
	[CustomEditor(typeof(AudioFile), true)]
	public class AudioFileEditor : Editor
	{
		[SerializeField] private AudioSource _previewer;

		public void OnEnable()
		{
			_previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio File preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
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
				AudioFile audioFile = (AudioFile)target;
				_previewer.volume = audioFile.ClampVolume.MaxValue;
				_previewer.PlayOneShot(audioFile.Source);
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