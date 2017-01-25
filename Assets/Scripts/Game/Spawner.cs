using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	GameObject spawnProto;

	void Awake () {
		GetComponent<SpriteRenderer>().enabled = false;
		spawnProto = transform.GetChild(0).gameObject;
		Spawn();
	}

	public virtual void Spawn () {
		var proto = Instantiate(spawnProto, transform.position, transform.rotation);
		proto.transform.parent = transform.parent;
		proto.SetActive(true);
	}
}
