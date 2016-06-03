using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public enum RotationAxes
	{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float SensitivityHori = 9.0f;
	public float SensitivityVert = 9.0f;

	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	private float _rotationX = 0;

	void start() {
		Rigidbody body = GetComponent<Rigidbody> ();
		if (body != null){
			body.freezeRotation = true;
		}
	}

	void Update () {
		if (axes == RotationAxes.MouseX){
			//horizontal rotation here
			transform.Rotate(0, Input.GetAxis("Mouse X") * SensitivityHori, 0);
		}
		else if (axes == RotationAxes.MouseY){
			//vertical rotation here
			_rotationX -= Input.GetAxis("Mouse Y") * SensitivityVert;
			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);

			float _rotationY = transform.localEulerAngles.y;
			transform.localEulerAngles = new Vector3 (_rotationX, _rotationY, 0);

		}
		else {
			//both horizontal and vertical rotation here
			_rotationX -= Input.GetAxis("Mouse Y") * SensitivityVert;
			_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);

			float delta = Input.GetAxis ("Mouse X") * SensitivityHori;
			float rotationY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
		}
	}



}
