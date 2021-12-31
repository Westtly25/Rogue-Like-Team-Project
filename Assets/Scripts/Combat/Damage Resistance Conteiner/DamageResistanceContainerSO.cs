using UnityEngine;

namespace RogueLike.Combat
{
    [CreateAssetMenu(fileName = "Scriptable Damage Resistance Container", menuName = "Rogue Like Prototype/Combat/Resistance Container/Scriptable Damage Resistance Container", order = 0)]
    public class DamageResistanceContainerSO : ScriptableObject
    {
        [SerializeField] private int id;
        [SerializeField] private ResistanceVariable[] resistanceVariables;

        public int ID { get => id; set => id = value; }
        public ResistanceVariable[] ResistanceVariable => resistanceVariables;
    }
}