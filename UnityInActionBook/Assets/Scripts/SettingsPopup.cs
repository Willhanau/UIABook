using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour {
	[SerializeField] private Slider speedSlider;

	void Awake(){
		speedSlider.value = PlayerPrefs.GetFloat ("speed", 1.0f); //sets speedSlider to saved player speed setting
	}

	public void Open(){
		gameObject.SetActive (true);
	}

	public void Close(){
		gameObject.SetActive (false);
	}

	public void OnSubmitName(string name){
		Debug.Log (name);
	}

	public void OnSpeedValue(float speed){
		Messenger<float>.Broadcast (GameEvent.SPEED_CHANGED, speed);
		PlayerPrefs.SetFloat ("speed", speed); //saves player speed setting
	}

}
