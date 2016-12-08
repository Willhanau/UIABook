using UnityEngine;
using System.Collections;

public class OrbitCamera : MonoBehaviour {
	[SerializeField] private Transform target;
	private Vector3 _offset;
	private float _rotY;
	public float rotSpeed = 1.5f;

	void Start () {
		_rotY = transform.eulerAngles.y;
		_offset = target.position - transform.position;
	}

	void LateUpdate () {
		float horInput = Input.GetAxis ("Horizontal");
		if (horInput != 0) {
			_rotY += horInput * rotSpeed;
		} else {
			_rotY += Input.GetAxis ("Mouse X") * rotSpeed * 3;
		}

		Quaternion rotation = Quaternion.Euler (0, _rotY, 0);
		transform.position = target.position - (rotation * _offset);
		transform.LookAt (target);
	}
}
