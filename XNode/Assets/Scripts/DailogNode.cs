using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DailogNode : Node {

    [Input] public int enter;

    [Output] public int yes;
    [Output] public int no;

    public bool isEndNode;
    public string text = "";

    private DailogNode previousNode;

    public void NextNode(string _exit)
    {
        DailogNode b = null;
        foreach (NodePort p in this.Ports)
        {
            if (p.fieldName == _exit)
            {
                b = p.Connection.node as DailogNode;
                break;
            }
        }
        if (b != null)
        {
            DialogNodeGraph _graph = this.graph as DialogNodeGraph;
            b.SetPreviousNode(this);
            _graph.SetCurrentNode(b);
        }
    }
    public void Yes() =>
    NextNode("yes");

    public void No() =>
        NextNode("no");
    public void SetPreviousNode(DailogNode node) =>
        previousNode = node;

    public DailogNode GetPreviousNode() =>
        previousNode;


}