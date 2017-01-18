using UnityEngine;
using System.Collections;

public class Tree3 : Genable {
	public bool debug;
	public Material trunkMaterial;
	public Material branchMaterial;

	void Start () {
		this.Generate ();
	}

	public override void RandomizeSeed ()
	{
		
	}
	
	public override void Generate ()
	{
		this.ClearMesh ();
		this.AddGenableMesh (GenableTools.MakeHair (this.trunkMaterial, 0.1f, Vector3.up * 0.01f + Vector3.left * 0.01f, 25, Vector3.zero, Vector3.up, 10.0f, this.debug));
		this.AddGenableMesh (GenableTools.MakeHair (this.branchMaterial, 0.02f, Vector3.up * 0.01f, 25, Vector3.up * 10.0f, Vector3.forward, 2.0f, this.debug));
	}
}
