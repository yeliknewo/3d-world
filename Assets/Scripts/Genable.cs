using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(GenableHook))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public abstract class Genable : MonoBehaviour {
	public abstract void Generate ();
	public abstract void RandomizeSeed ();

	protected MeshFilter meshFilter {
		get {
			return this.GetComponent<MeshFilter> ();
		}
	}

	public Mesh mesh {
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
		this.meshCount += 1;
		this.mesh.subMeshCount = this.meshCount;
		Material[] materials = new Material[this.meshRenderer.sharedMaterials.Length + 1];
		this.meshRenderer.sharedMaterials.CopyTo (materials, 0);
		materials [materials.Length - 1] = genableMesh.material;
		this.meshRenderer.sharedMaterials = materials;
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

		foreach (int oldTriangle in genableMesh.triangles) {
			newTriangles.Add (oldTriangle + startingVertexCount);
		}
		this.mesh.SetTriangles (newTriangles, this.meshCount - 1);

		if (this.meshCollider != null) {
			this.meshCollider.sharedMesh = this.mesh;
		}
	}

	public string assetPath;
	private int meshCount;

	public void ClearMesh() {
		assetPath = "Assets/GenableMesh/_" + this.gameObject.name + ".asset";
		this.meshCount = 0;
		this.meshRenderer.sharedMaterials = new Material[0];
	}
}
