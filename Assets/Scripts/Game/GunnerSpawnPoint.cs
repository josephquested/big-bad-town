using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerSpawnPoint : SpawnPoint {
	public float frequency;

	public override void Spawn () {
		var prefab = Instantiate(spawnPrefab, transform.position, transform.rotation);
		prefab.GetComponent<Animates>().direction = direction;
		prefab.GetComponent<AutoFires>().frequency = frequency;
		prefab.transform.parent = transform.parent;
	}
}
