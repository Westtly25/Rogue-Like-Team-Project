using UnityEngine;
using System.Diagnostics;
using System;

namespace RogueLike.SpecialAbility
{
    public class AbilityListView : MonoBehaviour
    {
        [SerializeField] private AbilityContainerSO abilityContainerSO;

        [SerializeField] private ActionBarSlot abilitySlotPrefab;

        [ContextMenu("Initialize")]
        private void Initialize()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Populate();
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            UnityEngine.Debug.Log(elapsedTime);
        }

        private void Populate()
        {
            if (abilityContainerSO == null) { return; }

            foreach (var specialization in abilityContainerSO.SpecializationSOsList)
            {
                foreach (var abilitySO in specialization.AbilitySOsList)
                {
                    //AbilitySlot abilitySlot = Instantiate(abilitySlotPrefab, this.transform);
                    //abilitySlot.SetAbility(abilitySO);
                }
            }
        }
    }
}