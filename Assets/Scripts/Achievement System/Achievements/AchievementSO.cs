using UnityEngine;

namespace RogueLike.Achievements
{
    [CreateAssetMenu(fileName = "AchievementSO", menuName = "Rogue Like Prototype/ Achievement System/ AchievementSO", order = 0)]
    public class AchievementSO : ScriptableObject, IAchievement
    {
        [SerializeField] private Sprite icon;
        [SerializeField] private string title;
        [SerializeField] private string description;

        public Sprite Icon => icon;

        public string Title => title;

        public string Description => description;
    }
}
