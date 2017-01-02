using UnityEngine;
using System.Collections;

public class RelativeMovement : MonoBehaviour {
	[SerializeField] private Transform target;

	// Update is called once per frame
	void Update () {
		Vector3 movement = Vector3.zero;
		float horInput = Input.GetAxis ("Horizontal");
		float vertInput = Input.GetAxis ("Vertical");
		if (horInput != 0 || vertInput != 0) {
			movement.x = horInput;
			movement.z = vertInput;

			Quaternion tmp = target.rotation;
			target.eulerAngles = new Vector3 (0, target.eulerAngles.y, 0);
			movement = target.TransformDirection (movement);
			target.rotation = tmp;

			transform.rotation = Quaternion.LookRotation (movement);
		}
	}
}
