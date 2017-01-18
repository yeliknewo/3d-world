using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Vector2 mousePositionLast = Vector2.zero;

	private new Camera camera {
		get {
			return this.GetComponentInChildren<Camera> ();
		}
	}

	void Start () {
	
	}

	void Update () {
		Vector3 movementVector = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

		this.transform.position += movementVector * Time.deltaTime;

		Vector2 deltaMouse = (Vector2)mousePositionLast - (Vector2)Input.mousePosition;

		camera.transform.Rotate (new Vector3 (deltaMouse.x, deltaMouse.y, 0));
		mousePositionLast = Input.mousePosition;
	}
}
