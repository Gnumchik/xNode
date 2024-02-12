using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using XNode;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private DialogNodeGraph graph;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Button yes;
    [SerializeField] private Button no;
    [SerializeField] private Button retuern;

    void Start()
    {
        yes.onClick.AddListener(Yes);
        no.onClick.AddListener(No);
        retuern.onClick.AddListener(Back);
        graph.Start();
    }

    void Update()
    {
        text.text = graph.GetCurrentNode().text;
        if (graph.GetCurrentNode().isEndNode)
        {
            yes.gameObject.SetActive(false);
            no.gameObject.SetActive(false);
        }
        else if (!graph.GetCurrentNode().isEndNode)
        {
            yes.gameObject.SetActive(true);
            no.gameObject.SetActive(true);
        }
    }

    private void Yes() =>
        graph.GetCurrentNode().Yes();

    private void No() =>
        graph.GetCurrentNode().No();

    private void Back()
    {
        if (graph.GetCurrentNode().GetPreviousNode())
            graph.SetCurrentNode(graph.GetCurrentNode().GetPreviousNode());
    }
}