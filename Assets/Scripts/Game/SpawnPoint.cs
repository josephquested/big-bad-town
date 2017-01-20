﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
	public GameObject spawnPrefab;
	public int direction;

	void Awake () {
		GetComponent<SpriteRenderer>().enabled = false;
		Spawn();
	}

	public virtual void Spawn () {
		var prefab = Instantiate(spawnPrefab, transform.position, transform.rotation);
		prefab.GetComponent<Animates>().direction = direction;
		prefab.transform.parent = transform.parent;
	}
}
