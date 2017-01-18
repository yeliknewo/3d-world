using UnityEngine;
using System.Collections;

public class Sphere1 : Genable {
	public bool debug;
	public Material sphereMaterial;

	void Start () {
		this.Generate ();
	}

	public override void Generate ()
	{
		this.ClearMesh ();
		Vector3 uvDivs = Vector3.one * 4.0f;
		this.AddGenableMesh (GenableTools.MakeSphere (this.sphereMaterial, 5.0f, Vector3.zero, 10, 10, uvDivs, this.debug));
	}

	public override void RandomizeSeed ()
	{
		
	}
}
