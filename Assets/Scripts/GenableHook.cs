using UnityEngine;
using System.Collections;

public class GenableHook : MonoBehaviour {
	public void Generate() {
		GetComponent<Genable> ().Generate ();
	}
}
