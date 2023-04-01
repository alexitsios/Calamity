using UnityEditor;
using UnityEngine;

namespace Calamity.Primitives
{
    [CustomPropertyDrawer(typeof(IntReference))]
    public class IntReferenceDrawer : PropertyDrawer
    {
        /// <summary>
        /// Options to display in the popup to select constant or variable.
        /// </summary>
        private readonly string[] popupOptions =
            { "Use Constant", "Use Formula", "Use Variable" };

        /// <summary> Cached style to use to draw the popup button. </summary>
        private GUIStyle popupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (popupStyle == null)
            {
                popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                popupStyle.imagePosition = ImagePosition.ImageOnly;
            }

            // Calculate rect for configuration button
            Rect newPosition = new Rect(position);
            position.xMin = position.xMin;

            label = EditorGUI.BeginProperty(newPosition, label, property);
            position = EditorGUI.PrefixLabel(newPosition, label);

            EditorGUI.BeginChangeCheck();

            // Get properties
            SerializedProperty useConstant = property.FindPropertyRelative("UseConstant");
            SerializedProperty constantValue = property.FindPropertyRelative("ConstantValue");
            SerializedProperty useFormula = property.FindPropertyRelative("UseFormula");
            SerializedProperty formula = property.FindPropertyRelative("Formula");
            SerializedProperty variable = property.FindPropertyRelative("Variable");

            // Calculate rect for configuration button
            Rect buttonRect = new Rect(newPosition);
            buttonRect.yMin += popupStyle.margin.top;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right + 100;
            position.xMin = buttonRect.xMax;

            // Store old indent level and set it to 0, the PrefixLabel takes care of it
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            int result = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 0 : useFormula.boolValue ? 1 : 2, popupOptions, popupStyle);

            useConstant.boolValue = result == 0;
            useFormula.boolValue = result == 1;

            EditorGUI.PropertyField(position,
                useConstant.boolValue ? constantValue : useFormula.boolValue ? formula : variable,
                GUIContent.none);

            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}