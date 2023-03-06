using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Scriptable Objects/Items/Equipment")]
public class Equipment : Item
{
    //Right now this is under the assumption that the only equipment in the game is weapons
    //If that changes, I will likely make a new Weapon script which inherits from this one
    [Header("Equipment Properties")]
    [SerializeField] private int m_baseMagazineCount;
    [SerializeField] private int m_baseDamage;
    [SerializeField] private int m_baseCriticalDamage;

    public int BaseMagazineCount => m_baseMagazineCount;
    public int BaseDamage => m_baseDamage;
    public int BaseCriticalDamage => m_baseCriticalDamage;

    public override void UseItem()
    {
        Debug.Log("Equipping " + Name);
    }
}
