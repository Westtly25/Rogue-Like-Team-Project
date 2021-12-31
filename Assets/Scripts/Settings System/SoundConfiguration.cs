using System;
using Helpers.Observers;

public class SoundConfiguration : ISoundConfiguration
{
    private IObservableValue<bool> isSoundEnable = new ObservableValue<bool>(true);
    private IObservableValue<float> mainVolume = new ObservableValue<float>(0.5f);
    private IObservableValue<float> effectsVolume = new ObservableValue<float>(0.5f);
    private IObservableValue<float> musicVolume = new ObservableValue<float>(0.5f);


    public IObservableValue<bool> IsSoundEnable => isSoundEnable;
    public IObservableValue<float> MainVolume => mainVolume;
    public IObservableValue<float> EffectsVolume => effectsVolume;
    public IObservableValue<float> MusicVolume => musicVolume;

    public void Initialize()
    {
        IsSoundEnable.ValueChanged += IsSoundEnableOnValueChanged;
        MainVolume.ValueChanged += MainVolumeOnValueChanged;
        EffectsVolume.ValueChanged += EffectsVolumeOnValueChanged;
        MusicVolume.ValueChanged += MusicVolumeOnValueChanged;
    }

    private void IsSoundEnableOnValueChanged(bool value)
    {

    }

    private void MainVolumeOnValueChanged(float value)
    {

    }

    private void EffectsVolumeOnValueChanged(float value)
    {

    }

    private void MusicVolumeOnValueChanged(float value)
    {

    }
}