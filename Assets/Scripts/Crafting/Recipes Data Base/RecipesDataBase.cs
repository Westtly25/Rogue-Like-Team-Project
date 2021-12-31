using UnityEngine;

namespace RogueLike.Crafting
{
    [CreateAssetMenu(fileName = "Recipes Data Base", menuName = "Rogue Like Prototype/Crafting/Data Base/New Recipes Data Base", order = 0)]
    public class RecipesDataBase : ScriptableObject
    {
        [SerializeField] private ScriptableCraftingRecipes[] craftingRecipes;
    }
}