using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AStarSeach : SearchAlgorithm {

	private HashSet<object> openSet = new HashSet<object> ();
	private HashSet<object> closedSet = new HashSet<object> ();

	// Use this for initialization
	void Start () {
		problem = GameObject.Find ("Map").GetComponent<Map> ().GetProblem();
		SearchNode start = new SearchNode (problem.GetStartState (), 0, problem.getRemainingGoals);
		openSet.Add (start.state);
	}

	protected override void Step()
	{
		if (openSet.Count > 0) { 
			SearchNode cur_node = openSet[0];

			for (int i = 1; i < openSet.c; i++) {
				if (openSet [i].fcost < cur_node.fcost || openSet [i].fcost == cur_node.fcost && openSet [i].hcost < cur_node.hcost) {
					cur_node = openSet [i];
				}
			}
			openSet.Remove (cur_node.state);
			closedSet.Add (cur_node.state);

			if (problem.IsGoal (cur_node.state)) {
				solution = cur_node;
				finished = true;
				running = false;
			}

				
			Successor[] sucessors = problem.GetSuccessors (cur_node.state);
			foreach (Successor suc in sucessors) {
				SearchNode new_node = new SearchNode (suc.state, suc.cost + cur_node.g, suc.action, cur_node);
				if (closedSet.Contains (suc)) {
					continue;
				}

				if (problem.getRemainingGoals (cur_node.state) < problem.getRemainingGoals (suc.state)) {

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