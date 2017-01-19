using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour {

	PlayerInventory inventory;

	void Start () {
		inventory = transform.parent.GetComponent<PlayerInventory>();
	}

	void OnTriggerStay2D (Collider2D collider) {
		if (collider.tag == "LockedDoor" && Input) {

		}
	}
}
