using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
	[SerializeField] private Text scoreLabel;
	[SerializeField] private SettingsPopup settingsPopup;
	private int _score;

	void Awake(){
		Messenger.AddListener (GameEvent.ENEMY_HIT, OnEnemyHit);
	}

	void onDestroy(){
		Messenger.RemoveListener (GameEvent.ENEMY_HIT, OnEnemyHit);
	}

	// Use this for initialization
	void Start () {
		_score = 0;
		scoreLabel.text = _score.ToString ();
		settingsPopup.Close ();
	}

	public void OnEnemyHit(){
		_score += 1;
		scoreLabel.text = _score.ToString ();
	}

	public void OnOpenSettings(){
		settingsPopup.Open();
	}

	public void OnPointerDown(){
		Debug.Log ("pointer down");
	}

}
