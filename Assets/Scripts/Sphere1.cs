using UnityEngine;
using System.Collections;

public class Sphere1 : Genable {
	public bool debug;

	void Start () {
		this.Generate ();
	}

	public override void Generate ()
	{
		this.ClearMesh ();
		this.AddGenableMesh (GenableTools.MakeSphere (5.0f, Vector3.zero, 10, 10, this.debug));
	}
}
