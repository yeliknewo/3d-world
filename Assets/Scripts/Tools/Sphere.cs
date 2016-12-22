using UnityEngine;
using System.Collections.Generic;

public class Sphere {
	public static GenableMesh Make(float radius, Vector3 position, int sides, int halfIterations, bool debug) {
		List<Vector3> nodes = new List<Vector3> ();
		List<float> nodeSizes = new List<float> ();

		for (int i = -halfIterations; i <= halfIterations; i++) {
			float x = (float)i / (float)halfIterations * radius;
			float absX = radius - Mathf.Abs(x);
			Vector3 node = position + Vector3.forward * x;
			float nodeSize = Mathf.Sqrt (absX * (2 * radius - absX));

			nodes.Add (node);
			nodeSizes.Add (nodeSize);
		}

		return GenableTools.MakeHose (nodes, nodeSizes, sides, debug);
	}
}

