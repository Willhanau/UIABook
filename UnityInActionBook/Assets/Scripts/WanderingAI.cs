using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour {
	public const float baseSpeed = 3.0f;
	public float speed = 3.0f;
	public float obstacleRange = 5.0f;
	private bool _alive;
	[SerializeField] private GameObject fireballPrefab;
	private GameObject _fireball;

	void Awake(){
		Messenger<float>.AddListener (GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	void OnDestroy(){
		Messenger<float>.RemoveListener (GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	// Use this for initialization
	void Start () {
		_alive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (_alive) {
			transform.Translate (0, 0, speed * Time.deltaTime);
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.SphereCast (ray, 0.75f, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				if (hitObject.GetComponent<PlayerCharacter> ()) {
					if (_fireball == null) {
						_fireball = Instantiate (fireballPrefab) as GameObject;
						_fireball.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
						_fireball.transform.rotation = transform.rotation;
					}
				}
				else if (hit.distance < obstacleRange) {
					float angle = Random.Range (-110, 110);
					transform.Rotate (0, angle, 0);
				}
			}
		}
	}

	public bool GetAlive(){
		return _alive;
	}

	public void SetAlive(bool alive){
		_alive = alive;
	}

	private void OnSpeedChanged(float value){
		speed = baseSpeed * value;
	}

}
