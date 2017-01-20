using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
	public GameObject spawnPrefab;

	void Awake () {
		GetComponent<SpriteRenderer>().enabled = false;
		Spawn();
	}

	public void Spawn () {
		var prefab = Instantiate(spawnPrefab, transform.position, transform.rotation);
		prefab.transform.parent = transform.parent;
	}
}
