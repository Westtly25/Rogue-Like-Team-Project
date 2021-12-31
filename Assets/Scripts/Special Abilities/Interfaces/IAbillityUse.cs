using UnityEngine;
using System.Collections;

namespace RogueLike.SpecialAbility
{
    public interface IAbillityUse
    {
        IEnumerator Cast();
    }
}