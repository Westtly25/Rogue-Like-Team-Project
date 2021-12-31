using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecoratorNode : Node
{
    [SerializeField] private Node childNode;

    public Node ChildNode{ get => childNode; set => childNode = value; }
}
