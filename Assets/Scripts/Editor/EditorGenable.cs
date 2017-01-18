using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(GenableHook))]
public class EditorGenable : Editor {
	public override void OnInspectorGUI() {
		GenableHook myTarget = (GenableHook)target;

		if (GUILayout.Button ("Generate")) {
			this.Generate (myTarget.GetComponent<Genable>());
		}

		if (GUILayout.Button ("Generate All")) {
			this.Generate (myTarget.GetComponent<Genable>());
			foreach(Genable genable in myTarget.GetComponentsInChildren<Genable> ()) {
				this.Generate (genable);
			}
		}

		if (GUILayout.Button ("Randomize Seed")) {
			myTarget.GetComponent<Genable>().RandomizeSeed ();
		}
	}

	private void Generate(Genable genable) {
		genable.ClearMesh ();
		Mesh tempMesh = new Mesh();
		AssetDatabase.CreateAsset (tempMesh, genable.assetPath);
		genable.mesh = AssetDatabase.LoadAssetAtPath<Mesh> (genable.assetPath);
		genable.Generate ();
	}
}
