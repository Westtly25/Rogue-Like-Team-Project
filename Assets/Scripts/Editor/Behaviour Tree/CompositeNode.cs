using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CompositeNode : Node
{
    [SerializeField] private List<Node> childrenNodes = new List<Node>();
}