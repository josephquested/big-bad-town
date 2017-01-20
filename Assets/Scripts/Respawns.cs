using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawns : MonoBehaviour {
	public Vector2 spawnPosition;
	Moves moves;

	void Awake () {
		spawnPosition = transform.localPosition;
		if (GetComponent<Moves>() != null) {
			moves = GetComponent<Moves>();
		}
	}

	public void Respawn () {
		if (moves != null) {
			moves.canMove = false;
			if (GetComponent<ActorController>() != null) {
				GetComponent<ActorController>().StopMovement();
			}
		}
		transform.localPosition = spawnPosition;
	}

	public void Activate () {
		if (moves != null) {
			moves.canMove = true;
		}
	}
}
