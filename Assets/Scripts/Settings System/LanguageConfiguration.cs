using System;
using Helpers.Observers;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;

[Serializable]
public class LanguageConfiguration : ILanguageConfiguration, ISerializationCallbackReceiver
{
    [SerializeField] private string currentLocaleCode;

    private IObservableValue<Locale> currentLocale = new ObservableValue<Locale>(null);
    public IEnumerable<Locale> allLocales;

    public IObservableValue<Locale> CurrentLocale { get => currentLocale; private set => currentLocale = value; }
    public IEnumerable<Locale> AllLocales { get => allLocales; private set => allLocales = value; }

    public async Task Initialize()
    {
        await LocalizationSettings.InitializationOperation.Task;

        SetCurrentLocaleFromCode();

        AllLocales = LocalizationSettings.AvailableLocales.Locales;

        if(CurrentLocale.Value == null)
        {
            CurrentLocale.Value = LocalizationSettings.SelectedLocale;
        }
        else CurrentLocaleOnValueChanged(CurrentLocale.Value);

        CurrentLocale.ValueChanged += CurrentLocaleOnValueChanged;
    }

    private void SetCurrentLocaleFromCode()
    {
        if(String.IsNullOrEmpty(currentLocaleCode))
        {
            CurrentLocale.Value = null;
        }

        try
        {
            CurrentLocale.Value = LocalizationSettings.AvailableLocales.GetLocale(new LocaleIdentifier(currentLocaleCode));
        }
        catch (Exception e)
        {
            Debug.LogException(e);

            CurrentLocale.Value = LocalizationSettings.AvailableLocales.Locales.FirstOrDefault();
        }
    }

    private void CurrentLocaleOnValueChanged(Locale locale)
    {
        LocalizationSettings.SelectedLocale = locale;
    }

    public void OnBeforeSerialize()
    {
        if(CurrentLocale.Value == null)
        {
            currentLocaleCode = null;
            return;
        }

        currentLocaleCode = CurrentLocale.Value.Identifier.Code;
    }

    public void OnAfterDeserialize()
    {

    }
}