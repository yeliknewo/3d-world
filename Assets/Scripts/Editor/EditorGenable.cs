using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(GenableHook))]
public class EditorTree1 : Editor {
	public override void OnInspectorGUI() {
		GenableHook myTarget = (GenableHook)target;

		if (GUILayout.Button ("Generate")) {
			myTarget.Generate ();
		}
	}
}
