using System;
using Helpers.Observers;

public class GameConfiguration : IGameConfiguration
{
    private IObservableValue<bool> isEnemyHealthBarVisible = new ObservableValue<bool>(true);
    private IObservableValue<bool> isDamageTextShow = new ObservableValue<bool>(true);
    private IObservableValue<bool> isLootPicksAutomatic = new ObservableValue<bool>(true);

    public IObservableValue<bool> IsEnemyHealthBarVisible => isEnemyHealthBarVisible;
    public IObservableValue<bool> IsDamageTextShow => isDamageTextShow;
    public IObservableValue<bool> IsLootPicksAutomatic => isLootPicksAutomatic;


    public void Initialize()
    {
        IsEnemyHealthBarVisible.ValueChanged += VisibleEnemyHealthBarOnValueChanged;
        IsDamageTextShow.ValueChanged += VisibleDamageTextBarOnValueChanged;
        IsLootPicksAutomatic.ValueChanged += LootPickUpOnValueChanged;

        VisibleEnemyHealthBarOnValueChanged(IsEnemyHealthBarVisible.Value);
        VisibleDamageTextBarOnValueChanged(IsDamageTextShow.Value);
        LootPickUpOnValueChanged(IsLootPicksAutomatic.Value);
    }

    private void VisibleEnemyHealthBarOnValueChanged(bool value)
    {

    }

    private void VisibleDamageTextBarOnValueChanged(bool value)
    {

    }

    private void LootPickUpOnValueChanged(bool value)
    {
        
    }
}