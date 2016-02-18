using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

	public int speed = 3;

	void Update () {
		transform.Rotate (0, speed, 0);
	}
}
