using System.Collections.Generic;
using UnityEngine;
using Helpers.Observers;

public interface IGraphicsConfiguration
{
    public IObservableValue<Resolution> CurrentResolution { get; }
    public IEnumerable<Resolution> AllResolutions { get; }
}
