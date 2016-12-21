using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(GenableHook))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public abstract class Genable : MonoBehaviour {
	public abstract void Generate ();

	protected MeshFilter meshFilter {
		get {
			return this.GetComponent<MeshFilter> ();
		}
	}

	protected Mesh mesh {
		get {
			return this.meshFilter.sharedMesh;
		}
		set {
			this.meshFilter.sharedMesh = value;
		}
	}

	protected MeshRenderer meshRenderer {
		get {
			return this.GetComponent<MeshRenderer> ();
		}
	}

	protected MeshCollider meshCollider {
		get {
			return this.GetComponent<MeshCollider> ();
		}
	}

	protected void AddGenableMesh(GenableMesh genableMesh) {
		int startingVertexCount = this.mesh.vertexCount;
		int startingUVCount = this.mesh.uv.Length;

		List<Vector3> newVertices = new List<Vector3> ();
		newVertices.AddRange (this.mesh.vertices);
		newVertices.AddRange (genableMesh.vertices);
		this.mesh.SetVertices (newVertices);

		List<Vector2> newUVs = new List<Vector2> ();
		this.mesh.GetUVs (0, newUVs);
		newUVs.RemoveRange (startingUVCount, newUVs.Count - startingUVCount);
		newUVs.AddRange (genableMesh.uvs);
		this.mesh.SetUVs (0, newUVs);

		List<int> newTriangles = new List<int> ();
		newTriangles.AddRange (this.mesh.triangles);
		foreach (int oldTriangle in genableMesh.triangles) {
			newTriangles.Add (oldTriangle + startingVertexCount);
		}
		this.mesh.SetTriangles (newTriangles, 0);

		if (this.meshCollider != null) {
			this.meshCollider.sharedMesh = this.mesh;
		}
	}

	protected void ClearMesh() {
		this.mesh = new Mesh ();
	}
}
