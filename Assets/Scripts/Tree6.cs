using UnityEngine;
using System.Collections;

public class Tree6 : Genable {

	public bool debug;
	public int seed;
	public Material trunkMaterial;
	public Material branchMaterial;

	void Start () {
		this.Generate ();
	}

	public override void RandomizeSeed ()
	{
		this.seed = Random.Range (int.MinValue, int.MaxValue);
	}

	public override void Generate ()
	{
		this.ClearMesh ();
		Random.InitState (this.seed);
		GenableMesh trunk;
		{
			float trunkDeltaSize = 0.05f;

			Vector3 trunkCurve = Random.onUnitSphere;
			trunkCurve.y = 0;

			int trunkSides = 12;

			float trunkStartSize = 2.5f;

			trunk = GenableTools.MakeHair2 (this.trunkMaterial, trunkDeltaSize, trunkCurve * 0.01f, trunkSides, Vector3.zero, Vector3.up, trunkStartSize, Vector3.one * 4.0f, this.debug);
		}
		this.AddGenableMesh (trunk);
		for (int i = 0; i < 50; i++) {
			this.AddGenableMesh (GenableTools.MakeHair2 (this.branchMaterial, 0.02f, Random.onUnitSphere * 0.05f, 12, trunk.nodes [Random.Range (0, trunk.nodes.Count)], Vector3.down * 0.1f, 0.5f, Vector3.one, this.debug));
		}
	}
}
