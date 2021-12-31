using UnityEngine;

namespace RogueLike.QuestSystem
{
    [System.Serializable]
    public sealed class QuestReward
    {
        [SerializeField] private int playerExperience = 100;
        [SerializeField] private int battlePassExperience = 100;
        //[SerializeField] ItemObject[] rewardItems;
        [SerializeField] private RewardItem[] rewardItem;

        public int PlayerExperience
        {
            get
            {
                return playerExperience;
            }
        }

        public int BattlePassExperience
        {
            get
            {
                return battlePassExperience;
            }

        }
    }
}