using System;
using UnityEngine;

[Serializable]
public sealed class ClientConfiguration
{
    [SerializeField]
    public GameConfiguration gameConfiguration = new GameConfiguration();

    [SerializeField]
    public GraphicsConfiguration graphicsConfiguration = new GraphicsConfiguration();

    [SerializeField]
    public LanguageConfiguration languageConfiguration = new LanguageConfiguration();

    [SerializeField]
    public SoundConfiguration soundConfiguration = new SoundConfiguration();
}