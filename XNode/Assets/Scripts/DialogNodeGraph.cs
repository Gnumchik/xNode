using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[CreateAssetMenu]
public class DialogNodeGraph : NodeGraph 
{
	private DailogNode _currentNode;

	public void Start()
	{
		_currentNode = (DailogNode)nodes[0];
	}

	public void SetCurrentNode(DailogNode node) =>
		_currentNode = node;

	public DailogNode GetCurrentNode() => _currentNode;
}