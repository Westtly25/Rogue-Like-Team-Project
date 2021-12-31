using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RogueLike.Combat;

[CreateAssetMenu(fileName = "DamageResistanceDataContainerSO", menuName = "Rogue Like Prototype/Combat/Damage Resistance/DataBase/DamageResistanceDataContainerSO", order = 0)]
public class DamageResistanceDataContainerSO : ScriptableObject
{
    [SerializeField] private DamageResistanceContainerSO[] damageResistanceList;

    public void UpdateIDs()
    {
        if(damageResistanceList == null || damageResistanceList.Length <= 0) { return; }

        for (int i = 0; i < damageResistanceList.Length; i++)
        {
            damageResistanceList[i].ID = i;
        }
    }
}