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

	public void IncreaseMaxHealth () {
		var meatController = GameObject.FindWithTag("MeatController").GetComponent<HUDMeatController>();
		meatController.AddMeat();
		baseHealth += 3;
		FillHealth();
	}

	public void FillHealth () {
		health = baseHealth;
	}

	void Respawn () {
		FillHealth();
		spriteRenderer.enabled = true;
		actorCollider.enabled = true;
		transform.position = Vector3.zero;
	}
}
