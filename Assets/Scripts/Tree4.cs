using UnityEngine;
using System.Collections;

public class Tree4 : Genable {

	public int seed;
	public bool debug;

	void Start () {
		this.Generate ();
	}

	public override void Generate ()
	{
		this.ClearMesh ();
		Random.InitState(this.seed);
		for (int i = 0; i < 25; i++) {
			this.AddGenableMesh (GenableTools.MakeHair (0.02f, Random.onUnitSphere * 0.01f, 12, Vector3.zero, Random.insideUnitSphere, 1.0f, this.debug));
		}
	}
}
