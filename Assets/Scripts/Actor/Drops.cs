using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour {
	public GameObject[] drops;
	public int probability;

	public void AttemptDrop() {
		int num = Random.Range(0, 100);
		if (num <= probability) {
			int dropIndex = Random.Range(0, drops.Length);
			Drop(drops[dropIndex]);
		}
	}

	void Drop (GameObject dropObject) {
		Instantiate(dropObject, transform.position, Quaternion.identity);
	}
}
