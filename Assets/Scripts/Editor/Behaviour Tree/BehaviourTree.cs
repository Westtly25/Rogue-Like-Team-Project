using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BehaviourTree : ScriptableObject
{
    [SerializeField] private Node rootNode;
    [SerializeField] private State treeState = State.Running;

    public Node RootNode { get => rootNode; set => rootNode = value; }
    public State TreeState { get => treeState; set => treeState = value; }

    public State Update()
    {
        if( rootNode.State == State.Running )
        {
            treeState = rootNode.Update();
        }

        return treeState;
    }
}