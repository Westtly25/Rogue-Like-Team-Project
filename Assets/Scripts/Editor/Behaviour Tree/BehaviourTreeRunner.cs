using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTreeRunner : MonoBehaviour
{
    BehaviourTree behaviourTree;


    // Start is called before the first frame update
    void Start()
    {
        behaviourTree = ScriptableObject.CreateInstance<BehaviourTree>();

        var log = ScriptableObject.CreateInstance<DebugLogNode>();

        var loop = ScriptableObject.CreateInstance<RepeatNode>();
        loop.ChildNode = log;

        behaviourTree.RootNode = loop;
    }

    // Update is called once per frame
    void Update()
    {
        behaviourTree.Update();
    }
}
