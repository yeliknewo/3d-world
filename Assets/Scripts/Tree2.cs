using UnityEngine;
using System.Collections;

public class Tree2 : Genable {

	public int seed;
	public float shrinkRate;
	public Vector3 curveRate;
	public int sides;
	public Vector3 startNode;
	public Vector3 startDirection;
	public float startSize;
	public bool debug;
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
		this.AddGenableMesh (GenableTools.MakeHair (this.trunkMaterial, this.shrinkRate, this.curveRate, this.sides, this.startNode, this.startDirection, this.startSize, this.debug));
		this.AddGenableMesh (GenableTools.MakeHair (this.branchMaterial, this.shrinkRate, this.curveRate, this.sides, this.startNode + Vector3.forward * 10, this.startDirection, this.startSize, this.debug));
	}
}
