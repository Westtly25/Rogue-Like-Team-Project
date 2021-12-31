using UnityEngine;

public class AudioEvent : ScriptableAudioEvent
{
    [Header("Audio clips_______________________________________")]
    public AudioClip[] clips;
    [Header("Volume of clips___________________________________")]
    public float volume;

    public override void Play(AudioSource source)
    {
        if(clips.Length == 0) { return; }

        source.clip = clips[Random.Range(0, clips.Length)];
        source.volume = volume;
        source.Play();
    }
}
