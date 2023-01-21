using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UI;

[CustomEditor(typeof(StaticCameraController))]
[CanEditMultipleObjects]
public class CameraEditor : Editor
{
    public BoxCollider Collider { get; set; }


    private SliderInt Xslider;
    private SliderInt Yslider;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        //Collider.size = new Vector3(Xslider.value, Yslider.value, 1);
    }


    public override VisualElement CreateInspectorGUI()
    {
        VisualElement customInspector = new();

        Xslider = new()
        {
            lowValue = 1,
            highValue = 10,
            label = "X size",
            showInputField = true
        };

        Yslider = new()
        {
            lowValue = 1,
            highValue = 10,
            label = "Y size",
            showInputField = true
        };
        customInspector.Add(Xslider);
        customInspector.Add(Yslider);
        customInspector.Add(new Label("this is a work in process. Doesn't currently function"));
        return customInspector;
    }
}