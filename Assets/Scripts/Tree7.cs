using UnityEngine;
using System.Collections.Generic;

public class Tree7 : Genable {

	public bool debug;
	public int seed;

	void Start () {
		this.Generate ();
	}
	
	public override void Generate ()
	{
		this.ClearMesh ();
		Random.InitState (seed);
		List<GenableMesh> sticks = new List<GenableMesh> ();
		GenableMesh trunk;
		{
			float trunkDeltaSize = 0.05f;

			Vector3 trunkCurve = Random.onUnitSphere;
			trunkCurve.y = 0;

			int trunkSides = 12;

			float trunkStartSize = 2.5f;

			trunk = GenableTools.MakeHair2 (trunkDeltaSize, trunkCurve * 0.01f, trunkSides, Vector3.zero, Vector3.up, trunkStartSize, this.debug);
		}
		sticks.Add (trunk);
		this.AddGenableMesh (trunk);
		for (int i = 0; i < 50; i++) {
			GenableMesh mesh = GenableTools.MakeHair2 (0.02f, Random.onUnitSphere * 0.05f, 12, trunk.nodes [Random.Range (0, trunk.nodes.Count)], Vector3.down * 0.1f, 0.5f, this.debug);
			this.AddGenableMesh (mesh);
			sticks.Add (mesh);
		}

		foreach (GenableMesh mesh in sticks) {
			this.AddGenableMesh (GenableTools.MakeSphere (0.5f, mesh.nodes [mesh.nodes.Count - 1], 10, 10, this.debug));
		}
	}
}
