using UnityEngine;
using UnityEditor;

namespace Calamity.Primitives
{
	[CustomEditor(typeof(BoolVariable), true)]
	public class BoolEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);

			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Toggle Bool"))
			{
				((BoolVariable)target).Toggle();
			}
			GUILayout.EndHorizontal();

			EditorGUI.EndDisabledGroup();
		}
	}
}