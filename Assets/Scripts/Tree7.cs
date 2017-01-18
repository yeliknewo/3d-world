using UnityEngine;
using System.Collections.Generic;

public class Tree7 : Genable {

	public bool debug;
	public int seed;

	public Material branchMaterial;
	public int branchCount = 50;
	public float branchDeltaSize = 0.02f;
	public Vector3 branchCurve;
	public float branchCurveMultiplier = 0.05f;
	public int branchSides = 12;
	public Vector3 branchStartingDirection = Vector3.up;
	public float branchStartingDirectionMultiplier = 0.5f;
	public float branchStartingSize = 0.5f;

	public Material sphereMaterial;
	public float sphereSize = 1.0f;
	public int sphereSides = 10;
	public int sphereHalfIterations = 10;

	public Material trunkMaterial;
	public float trunkDeltaSize = 0.05f;
	public Vector3 trunkCurve;
	public float trunkCurveMultiplier = 0.01f;
	public int trunkSides = 12;
	public float trunkStartSize = 2.5f;

	public override void RandomizeSeed ()
	{
		this.seed = Random.Range (int.MinValue, int.MaxValue);
	}
	
	public override void Generate ()
	{
		this.ClearMesh ();
		Random.InitState (this.seed);
		List<GenableMesh> sticks = new List<GenableMesh> ();
		GenableMesh trunk;
		{
			this.trunkCurve = Random.onUnitSphere;
			this.trunkCurve.y = 0;
				
			trunk = GenableTools.MakeHair2 (this.trunkMaterial, this.trunkDeltaSize, this.trunkCurve * this.trunkCurveMultiplier, this.trunkSides, Vector3.zero, Vector3.up, this.trunkStartSize, Vector3.one * 4.0f, this.debug);
		}
		sticks.Add (trunk);
		this.AddGenableMesh (trunk);
		for (int i = 0; i < this.branchCount; i++) {
			Vector3 localBranchCurve = this.branchCurve;
			localBranchCurve = Random.onUnitSphere;
			GenableMesh mesh = GenableTools.MakeHair2 (this.branchMaterial, this.branchDeltaSize, localBranchCurve * this.branchCurveMultiplier, this.branchSides, trunk.nodes [Random.Range (0, trunk.nodes.Count)], this.branchStartingDirection * this.branchStartingDirectionMultiplier, this.branchStartingSize, Vector3.one, this.debug);
			this.AddGenableMesh (mesh);
			sticks.Add (mesh);
		}

		foreach (GenableMesh mesh in sticks) {
			this.AddGenableMesh (GenableTools.MakeSphere (this.sphereMaterial, this.sphereSize, mesh.nodes [mesh.nodes.Count - 1], this.sphereSides, this.sphereHalfIterations, Vector3.one, this.debug));
		}
	}
}
