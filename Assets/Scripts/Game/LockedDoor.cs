using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour {

	void Awake () {
		if (PlayerPrefs.GetInt(gameObject.name) == 1) {
			Destroy(gameObject);
		}
	}

	public void Unlock () {
		PlayerPrefs.SetInt(gameObject.name, 1);
		Destroy(gameObject);
	}
}
