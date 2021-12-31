using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : ScriptableObject
{
    [SerializeField] private State state = State.Running;
    [SerializeField] private bool started = false;

    public State State = State.Running;
    public bool Started = false;

    protected abstract void OnStart();
    protected abstract void OnStop();
    protected abstract State OnUpdate();

    public State Update()
    {
        if( !started )
        {
            OnStart();
            started = true;
        }

        state = OnUpdate();

        if(state == State.Failure || state == State.Succes)
        {
            OnStop();
            started = false;
        }

        return state;
    }
}


public enum State
{
    Running,
    Failure,
    Succes
}