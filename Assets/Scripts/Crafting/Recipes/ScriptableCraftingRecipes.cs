using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RogueLike.Crafting
{
    [CreateAssetMenu(fileName = "Scriptable Crafting Recipe", menuName = "Rogue Like Prototype/Crafting/Recipes/ScriptableCraftingRecipes", order = 0)]
    public class ScriptableCraftingRecipes : ScriptableObject
    {
        [SerializeField] CraftingResources[] craftingResources;
        
    }

    [Serializable]
    public class CraftingResources
    {
        public ScriptableMaterialType materialType;
        public int amount;
    }
}