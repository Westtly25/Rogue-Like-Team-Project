using UnityEngine;
using Zenject;
using System.IO;
using System;

[CreateAssetMenu(fileName = "Configuration Service", menuName = "Rogue Like Prototype/Settings/Configuration Service", order = 0)]
public class ConfigurationService : ScriptableObject, IConfigurationService, IInitializable, IDisposable
{
    private ClientConfiguration clientConfiguration;
    [SerializeField] private string configurationFilePath = "configuration.json";

    public IGameConfiguration GameConfiguration { get => clientConfiguration.gameConfiguration; }
    public ILanguageConfiguration Language { get => clientConfiguration.languageConfiguration; }
    public IGraphicsConfiguration Graphics { get => clientConfiguration.graphicsConfiguration; }
    public ISoundConfiguration Sound { get => clientConfiguration.soundConfiguration; }


    public void Initialize()
    {
        var filePath = Path.Combine(Application.persistentDataPath, configurationFilePath);

        try
        {
            clientConfiguration = JsonUtility.FromJson<ClientConfiguration>(File.ReadAllText(filePath));
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            clientConfiguration = new ClientConfiguration();
        }

        clientConfiguration.languageConfiguration.Initialize().Wait();
        clientConfiguration.gameConfiguration.Initialize();
        clientConfiguration.soundConfiguration.Initialize();
        clientConfiguration.graphicsConfiguration.Initialize();
    }

    public void Dispose()
    {
        var filePath = Path.Combine(Application.persistentDataPath, configurationFilePath);

        try
        {
            File.WriteAllText(filePath, JsonUtility.ToJson(clientConfiguration));
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
}