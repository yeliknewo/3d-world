using UnityEngine;
using System.Collections.Generic;

public class Hose {
	public static GenableMesh Make(List<Vector3> nodes, List<float> nodeSizes, int sides, bool debug) {
		GenableMesh mesh = new GenableMesh ();

		if (nodes.Count < 2) {
			return null;
		}

		for (int i = 0; i < nodes.Count; i++) {
			for (int s = 0; s < sides; s++) {
				Vector3 currentNode = nodes [i];
				float angle = (float)s / sides * 360;
				Vector3 axis;
				if (i > 0) {
					axis = currentNode - nodes [i - 1];
				} else {
					axis = nodes [i + 1] - currentNode;
				}
				if (debug) {
					Debug.Log ("Vertex Count: " + mesh.vertices.Count);
					Debug.Log ("Axis: " + axis);
					Debug.Log ("Index: " + i % nodes.Count);
					Debug.Log ("Size: " + nodeSizes [i % nodes.Count]);
				}
				Vector3 swivle = Vector3.forward;
				if (axis.normalized == swivle) {
					swivle = Vector3.right;
				}
				Vector3 vertex = currentNode + (Quaternion.AngleAxis (angle, axis) * Vector3.Cross(axis, swivle)).normalized * nodeSizes [i % nodes.Count];
				if (debug) {
					Debug.Log ("Current Node: " + currentNode);
					Debug.Log ("Vertex: " + vertex);
				}
				mesh.nodes.Add (currentNode);
				mesh.vertices.Add (vertex);
				mesh.uvs.Add (new Vector2 (vertex.x + vertex.z, vertex.y));
			}
		}

		for (int i = 0; i < mesh.vertices.Count / sides - 1; i++) {
			for (int s = 0; s < sides; s++) {
				mesh.triangles.Add ((i + 0) * sides + (s + 0) % sides);
				mesh.triangles.Add ((i + 0) * sides + (s + 1) % sides);
				mesh.triangles.Add ((i + 1) * sides + (s + 1) % sides);

				mesh.triangles.Add ((i + 1) * sides + (s + 1) % sides);
				mesh.triangles.Add ((i + 1) * sides + (s + 0) % sides);
				mesh.triangles.Add ((i + 0) * sides + (s + 0) % sides);
			}
		}

		for (int s = 0; s < sides; s++) {
			mesh.triangles.Add (mesh.vertices.Count - (s + 2) % sides - 1);
			mesh.triangles.Add (mesh.vertices.Count - (s + 1) % sides - 1);
			mesh.triangles.Add (mesh.vertices.Count - 1);	//fixed point for flat shape

			mesh.triangles.Add ((s + 2) % sides);
			mesh.triangles.Add ((s + 1) % sides);
			mesh.triangles.Add (0);	//fixed point for flat shape
		}

		return mesh;
	}
}

