	﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour {

	Inventory inventory;
	Moves moves;

	void Start () {
		inventory = transform.parent.GetComponent<Inventory>();
		moves = transform.parent.GetComponent<Moves>();
	}

	void Update () {
		UpdateDirection();
	}

	void UpdateDirection () {
		if (moves.direction == 0) {
			transform.rotation = Quaternion.Euler(0, 0, 180);
		}
		if (moves.direction == 1) {
			transform.rotation = Quaternion.Euler(0, 0, 90);
		}
		if (moves.direction == 2) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		if (moves.direction == 3) {
			transform.rotation = Quaternion.Euler(0, 0, 270);
		}
	}

	void OnTriggerStay2D (Collider2D collider) {
		if (collider.tag == "LockedDoor" && Input.GetButtonDown("Attack")) {
			if (inventory.lockpicks > 0) {
				inventory.Drop("lockpick", 1);
				collider.GetComponent<LockedDoor>().Unlock();
			}
		}
	}
}
