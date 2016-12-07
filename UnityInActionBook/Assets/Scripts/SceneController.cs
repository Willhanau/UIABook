using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab;
	private GameObject _enemy;
	private float speed = 3.0f;
	private float baseSpeed = 6.0f;

	void Awake(){
		Messenger<float>.AddListener (GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	void OnDestroy(){
		Messenger<float>.RemoveListener (GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (_enemy == null) {
			_enemy = Instantiate (enemyPrefab) as GameObject;
			_enemy.transform.position = new Vector3 (0, 1, 0);
			float angle = Random.Range (0, 360);
			_enemy.transform.Rotate (0, angle, 0);
			WanderingAI _ai = _enemy.GetComponent<WanderingAI> ();
			if (_ai != null) {
				_ai.speed = speed;
			}
		}

	}

	private void OnSpeedChanged(float value){
		speed = baseSpeed * value;
	}
}
