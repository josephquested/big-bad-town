using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
	public GameObject spawnPrefab;
	public int direction;
	public bool singleSpawn;

	void Awake () {
		GetComponent<SpriteRenderer>().enabled = false;
		Spawn();
	}

	public virtual void Spawn () {
		if (PlayerPrefs.GetInt(gameObject.name) == 1) {
			return;
		}

		var prefab = Instantiate(spawnPrefab, transform.position, transform.rotation);
		prefab.GetComponent<Animates>().direction = direction;
		prefab.GetComponent<Status>().spawner = gameObject;
		prefab.transform.parent = transform.parent;

		if (singleSpawn) {
			prefab.GetComponent<Status>().singleSpawn = true;
		}
	}
}
