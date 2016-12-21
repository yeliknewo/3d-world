using UnityEngine;
using System.Collections.Generic;

public class GenableTools : MonoBehaviour {
	public static GenableMesh MakeHair(float shrinkRate, Vector3 curveRate, int sides, Vector3 startNode, Vector3 startDirection, float startSize, bool debug) {
		return Hair.Make (shrinkRate, curveRate, sides, startNode, startDirection, startSize, debug);
	}

	public static GenableMesh MakeSphere(float radius, Vector3 position, int sides, bool debug) {
		return Sphere.Make (radius, position, sides, debug);
	}
}
