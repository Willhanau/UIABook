using UnityEngine;
using System.Collections;

public class SettingsPopup : MonoBehaviour {

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
		Debug.Log ("Speed: " + speed);
	}

}
