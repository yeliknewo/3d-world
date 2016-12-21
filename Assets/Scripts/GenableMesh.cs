using System.Collections.Generic;
using UnityEngine;

public class GenableMesh
{
	private List<Vector3> _nodes = new List<Vector3>();

	public List<Vector3> nodes {
		get {
			return _nodes;
		}
	}

	private List<Vector3> _vertices = new List<Vector3>();

	public List<Vector3> vertices {
		get {
			return _vertices;
		}
	}

	private List<Vector2> _uvs = new List<Vector2>();

	public List<Vector2> uvs {
		get {
			return _uvs;
		}
	}

	private List<int> _triangles = new List<int> ();

	public List<int> triangles {
		get {
			return _triangles;
		}
	}

	public GenableMesh () {

	}
}
