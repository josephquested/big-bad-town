using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public string type;
	public bool respawns = true;
	public int quantity;

	void Awake () {
		if (!respawns && PlayerPrefs.GetInt(gameObject.name) == 1) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Player") {
			collider.GetComponent<Inventory>().Pickup(type, quantity);
			GetPickup();
		}
	}

	void GetPickup () {
		if (!respawns) {
			PlayerPrefs.SetInt(gameObject.name, 1);
		}
		Destroy(gameObject);
	}
}
