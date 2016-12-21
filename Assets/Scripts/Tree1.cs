using UnityEngine;
using System.Collections.Generic;

public class Tree1 : Genable {

	public int seed;
	public float shrinkRate;
	public Vector3 curveRate;
	public int sides;
	public Vector3 startNode;
	public Vector3 startDirection;
	public float startSize;

	void Start () {
		this.Generate ();
	}

	public override void Generate ()
	{
		Random.InitState (this.seed);
		Mesh mesh = new Mesh ();
		List<Vector3> vertices = new List<Vector3> ();
		List<Vector2> uvs = new List<Vector2> ();
		List<int> triangles = new List<int> ();

		{
			List<Vector3> nodes = new List<Vector3> ();
			List<float> nodeSizes = new List<float> ();
			float shrinkRate = this.shrinkRate;
			Vector3 curveRate = this.curveRate;
			int sides = this.sides;
			Vector3 startNode = this.startNode;
			Vector3 startDirection = this.startDirection;
			float startSize = this.startSize;

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

			if (nodes.Count < 2) {
				return;
			}

			for (int i = 0; i < nodes.Count; i++) {
				for (int s = 0; s < sides; s++) {
					Vector3 currentNode = nodes [i];
					float angle = (float)s / sides * 360;
					Vector3 axis;
					if (i > 0) {
						axis = currentNode - nodes [i - 1];
					} else {
						axis = nodes[i + 1] - currentNode;
					}
					Vector3 vertex = currentNode + Quaternion.AngleAxis (angle, axis) * Vector3.forward * nodeSizes [i % nodes.Count];
					vertices.Add (vertex);
					uvs.Add (new Vector2 (vertex.x, vertex.z));
				}
			}

			for (int i = 0; i < vertices.Count / sides - 1; i++) {
				for (int s = 0; s < sides; s++) {
					triangles.Add ((i + 0) * sides + (s + 0) % sides);
					triangles.Add ((i + 0) * sides + (s + 1) % sides);
					triangles.Add ((i + 1) * sides + (s + 1) % sides);

					triangles.Add ((i + 1) * sides + (s + 1) % sides);
					triangles.Add ((i + 1) * sides + (s + 0) % sides);
					triangles.Add ((i + 0) * sides + (s + 0) % sides);
				}
			}

			for (int s = 0; s < sides; s++) {
				triangles.Add (vertices.Count - (s + 2) % sides - 1);
				triangles.Add (vertices.Count - (s + 1) % sides - 1);
				triangles.Add (vertices.Count - 1);	//fixed point for flat shape

				triangles.Add ((s + 2) % sides);
				triangles.Add ((s + 1) % sides);
				triangles.Add (0);	//fixed point for flat shape
			}
		}

		mesh.SetVertices (vertices);
		mesh.SetUVs (0, uvs);
		mesh.SetTriangles (triangles, 0);

		mesh.RecalculateNormals ();
		mesh.RecalculateBounds ();
		mesh.Optimize ();
		mesh.UploadMeshData (false);
		this.meshFilter.mesh = mesh;
	}
}
