using UnityEngine;

namespace RogueLike.Combat
{
    public interface IDamageType
    {
        public string Title { get; }
        public Sprite Icon { get; }
    }
}