using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace RogueLike.SpecialAbility
{
    public class AbilityOptionsListView : MonoBehaviour
    {
        [SerializeField] private AbilityOptionSlot slotPrefab;
        private List<AbilityOptionSlot> cacheSlots = new List<AbilityOptionSlot>();

        public void PopulateAbilityOptionsSO(AbilityOptionSO[] abilityOptionSOs)
        {
            if( abilityOptionSOs == null ) { return; }

            if(cacheSlots.Count >= abilityOptionSOs.Length) { return; }

            for (var i = 0; i < abilityOptionSOs.Length; i++)
            {
                AbilityOptionSlot slot = Instantiate(slotPrefab, transform);
                slot.SetData(abilityOptionSOs[i]);

                cacheSlots.Add(slot);
            }
        }
    }
}