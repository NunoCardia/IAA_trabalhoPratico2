using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LimitedDepthSearch : SearchAlgorithm {

	private ArrayList openQueue = new ArrayList();
	private HashSet<object> closedSet = new HashSet<object> ();
	public int limit;

	void Start () 
	{
		problem = GameObject.Find ("Map").GetComponent<Map> ().GetProblem();
		SearchNode start = new SearchNode (problem.GetStartState (), 0);
		openQueue.Add(start);
	}

	protected override void Step()
	{


		if (openQueue.Count > 0)
		{
			SearchNode cur_node = (SearchNode) openQueue[openQueue.Count-1];
			openQueue.RemoveAt (openQueue.Count - 1);
			closedSet.Add (cur_node.state);

			if (problem.IsGoal (cur_node.state)) {
				solution = cur_node;
				finished = true;
				running = false;
			} else {
				Successor[] sucessors = problem.GetSuccessors (cur_node.state);
				foreach (Successor suc in sucessors) {
					if (!closedSet.Contains (suc.state)) {
						SearchNode new_node = new SearchNode (suc.state, suc.cost + cur_node.g, suc.action, cur_node);
						if(limit > new_node.depth)
							openQueue.Add(new_node);
					}
				}
			}
		}
		else
		{
			finished = true;
			running = false;
		}
	}
}
