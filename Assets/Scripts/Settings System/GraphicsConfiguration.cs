using System;
using Helpers.Observers;
using UnityEngine;
using System.Collections.Generic;

public class GraphicsConfiguration : IGraphicsConfiguration
{
    private IObservableValue<Resolution> currentResolution = new ObservableValue<Resolution>(default);
    private IEnumerable<Resolution> allResolutions;

    public IObservableValue<Resolution> CurrentResolution { get => currentResolution; }
    public IEnumerable<Resolution> AllResolutions
    { 
        get => allResolutions;
        private set => allResolutions = value;
    }

    public void Initialize()
    {
        CurrentResolution.Value = Screen.currentResolution;
        AllResolutions = Screen.resolutions;

        CurrentResolution.ValueChanged += ResolutionOnValueChanged;
    }

    private void ResolutionOnValueChanged(Resolution resolution)
    {
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode, resolution.refreshRate);
    }
}