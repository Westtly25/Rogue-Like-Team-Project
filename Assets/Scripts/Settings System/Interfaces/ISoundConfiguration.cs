using Helpers.Observers;

public interface ISoundConfiguration
{
    public IObservableValue<bool> IsSoundEnable { get; }
    public IObservableValue<float> MainVolume { get; }
    public IObservableValue<float> EffectsVolume { get; }
    public IObservableValue<float> MusicVolume { get; }
}