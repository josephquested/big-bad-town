	﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : Status {

	void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	public override void Die () {
		spriteRenderer.enabled = false;
		actorCollider.enabled = false;
		Respawn();
	}

	void Respawn () {
		health = baseHealth;
		spriteRenderer.enabled = true;
		actorCollider.enabled = true;
		transform.position = Vector3.zero;
	}
}
