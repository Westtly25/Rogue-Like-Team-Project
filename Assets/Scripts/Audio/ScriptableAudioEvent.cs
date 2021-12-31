using UnityEngine;

public abstract class ScriptableAudioEvent : ScriptableObject
{
    public abstract void Play(AudioSource source);
}
