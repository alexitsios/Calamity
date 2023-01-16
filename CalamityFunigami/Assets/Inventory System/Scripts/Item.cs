using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Objects/Items/Generic")]
public class Item : ScriptableObject
{
    [SerializeField] new private string name;
    [SerializeField] private string m_description;
    [SerializeField] private GameObject m_UIElementPrefab;
    [Space]
    [SerializeField] private int m_width;
    [SerializeField] private int m_height;
    [Space]
    [SerializeField] private bool m_canStack;
    [SerializeField] private bool m_canRotate;

    public string Name => name;
    public string Description => m_description;
    public GameObject UIElementPrefab => m_UIElementPrefab;

    public int Height => m_height;
    public int Width => m_width;

    public bool CanStack => m_canStack;
    public bool CanRotate => m_canRotate;
}
