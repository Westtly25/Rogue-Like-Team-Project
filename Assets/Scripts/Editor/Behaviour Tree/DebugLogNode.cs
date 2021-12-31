using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogNode : ActionNode
{
    [SerializeField] private string message;
    public string Message { get => message; set => message = value; }

    protected override void OnStart()
    {
        Debug.Log($"OnStart {message}");
    }

    protected override void OnStop()
    {
        Debug.Log($"OnStop {message}");

    }

    protected override State OnUpdate()
    {
        Debug.Log($"OnUpdate {message}");

        return State.Succes;
    }
}