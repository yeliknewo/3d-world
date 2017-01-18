using UnityEngine;
using System.Collections.Generic;

public class GenableTools : MonoBehaviour {
	public static GenableMesh MakeHair(Material material, float shrinkRate, Vector3 curveRate, int sides, Vector3 startNode, Vector3 startDirection, float startSize, bool debug) {
		return Hair.Make (material, shrinkRate, curveRate, sides, startNode, startDirection, startSize, debug);
	}

	public static GenableMesh MakeHair2(Material material, float shrinkRate, Vector3 curveRate, int sides, Vector3 startNode, Vector3 startDirection, float startSize, Vector3 uvDivs, bool debug) {
		return Hair2.Make (material, shrinkRate, curveRate, sides, startNode, startDirection, startSize, uvDivs, debug);
	}

	public static GenableMesh MakeSphere(Material material, float radius, Vector3 position, int sides, int halfIterations, Vector3 uvDivs, bool debug) {
		return Sphere.Make (material, radius, position, sides, halfIterations, uvDivs, debug);
	}

	public static GenableMesh MakeHose(Material material, List<Vector3> nodes, List<float> nodeSizes, int sides, Vector3 uvDivs, bool debug) {
		return Hose.Make (material, nodes, nodeSizes, sides, uvDivs, debug);
	}
}
