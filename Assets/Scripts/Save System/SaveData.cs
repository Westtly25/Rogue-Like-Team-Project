using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RogueLike.InventorySystem;
using RogueLike.QuestSystem;

[Serializable]
public class SaveData
{
    private static SaveData current;
    public static SaveData Current
    {
        get
        {
            if(current == null)
            {
                current = new SaveData();
            }

            return current;
        }
        set
        {
            if(value != null)
            {
                current = value;
            }
        }
    }
    
    public List<Quest> Quests = new List<Quest>();
}
