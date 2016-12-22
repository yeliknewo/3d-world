using UnityEngine;
using System.Collections.Generic;

public class Hair2
{
	public static GenableMesh Make(float shrinkRate, Vector3 curveRate, int sides, Vector3 startNode, Vector3 startDirection, float startSize, bool debug) {
		List<Vector3> nodes = new List<Vector3> ();
		List<float> nodeSizes = new List<float> ();

		if (startSize - 2 * shrinkRate > 0) {
			nodes.Add (startNode);
			nodeSizes.Add (startSize);
			Vector3 lastNode = startNode;

			for (float size = startSize - shrinkRate; size > 0; size -= shrinkRate) {
				startDirection += curveRate;
				Vector3 nextNode = lastNode + startDirection;
				nodes.Add (nextNode);
				nodeSizes.Add (size);
				lastNode = nextNode;
			}
		}

		return Hose.Make (nodes, nodeSizes, sides, debug);
	}
}