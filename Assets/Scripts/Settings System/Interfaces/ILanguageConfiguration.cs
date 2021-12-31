using UnityEngine.Localization;
using Helpers.Observers;
using System.Collections.Generic;

public interface ILanguageConfiguration
{
    public IObservableValue<Locale> CurrentLocale { get; }
    public IEnumerable<Locale> AllLocales { get; }
}