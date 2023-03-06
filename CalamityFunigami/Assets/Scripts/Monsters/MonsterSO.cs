using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Scriptable Objects/Monsters/Generic")]
public class MonsterSO : ScriptableObject
{
    [SerializeField] new private string name = "New Monster";
    [SerializeField] private GameObject m_monsterPrefab;
    [Space]
    [TextArea(3,5)]
    [SerializeField] private string m_description;
    [TextArea(2,3)]
    [SerializeField] private string[] m_bestiaryEntrances;

    public string Name => name;
    public GameObject MonsterPrefab => m_monsterPrefab;
    public string Description => m_description;
    public string[] BestiaryEntrances => m_bestiaryEntrances;
}
