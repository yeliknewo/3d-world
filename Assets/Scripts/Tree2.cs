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

	void Start () {
		this.Generate ();
	}

	public override void Generate ()
	{
		this.ClearMesh ();
		this.AddGenableMesh (GenableTools.MakeHair (shrinkRate, curveRate, sides, startNode, startDirection, startSize, this.debug));
		this.AddGenableMesh (GenableTools.MakeHair (shrinkRate, curveRate, sides, startNode + Vector3.forward * 10, startDirection, startSize, this.debug));
	}
}
