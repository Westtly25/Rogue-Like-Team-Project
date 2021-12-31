using UnityEngine;

public interface IAchievement
{
    Sprite Icon { get; }
    string Title { get; }
    string Description { get; }
}
