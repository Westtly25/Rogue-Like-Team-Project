using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfigSO", menuName = "Rogue Like Prototype/Level Generator System/ Levels /LevelConfigSO", order = 0)]
public class LevelConfigSO : ScriptableObject
{
    [SerializeField] private Room[] availableRooms;
}