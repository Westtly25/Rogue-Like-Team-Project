using Helpers.Observers;

public interface IGameConfiguration
{
    public IObservableValue<bool> IsEnemyHealthBarVisible { get; }
    public IObservableValue<bool> IsDamageTextShow { get; }
    public IObservableValue<bool> IsLootPicksAutomatic { get; }
}