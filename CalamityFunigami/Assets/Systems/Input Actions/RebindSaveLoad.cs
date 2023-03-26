using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Samples.RebindUI;

public class RebindSaveLoad : MonoBehaviour
{
    [SerializeField] private InputActionAsset actions;

    [SerializeField] private RebindActionUI[] actionRebinds;

    public void OnEnable()
    {
        var rebinds = PlayerPrefs.GetString("rebinds");
        if (!string.IsNullOrEmpty(rebinds))
        {
            actions.LoadBindingOverridesFromJson(rebinds);
        }

        for (int i = 0; i < actionRebinds.Length; i++)
        {
            actionRebinds[i].UpdateBindingDisplay();
        }
    }

    public void OnDisable()
    {
        var rebinds = actions.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString("rebinds", rebinds);
    }
}
