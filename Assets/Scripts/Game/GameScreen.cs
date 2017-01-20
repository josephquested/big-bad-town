using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : MonoBehaviour {
	ScreenController screenController;

	public List<GameObject> respawnObjects;
	public bool screenActive = false;

	void Start () {
		screenController = transform.parent.GetComponent<ScreenController>();
		foreach (Transform child in transform) if (child.gameObject.GetComponent<SpawnPoint>() != null) {
			respawnObjects.Add(child.gameObject);
		}
	}

	void Update () {
		screenController.SetGameScreenState(this);
	}

	void OnTriggerStay2D (Collider2D collider) {
		if (collider.tag == "Player") {
			screenController.SetGameScreen(this);
		}
	}

	public void ResetGameScreen ()
	{
		if (!screenActive) return;
		screenActive = false;

		// clears all alive enemies from the screen
		foreach (Transform child in transform) if (child.gameObject.tag == "Enemy") {
			Destroy(child.gameObject);
		}

		// respawns objects in screen
		foreach (GameObject obj in respawnObjects) {
			obj.GetComponent<SpawnPoint>().Spawn();
		}
  }

	public void ActivateGameScreen () {
		if (screenActive) return;
		screenActive = true;

		// activates all actors in the screen
		foreach (Transform child in transform) if (child.gameObject.GetComponent<ActorController>() != null) {
			child.gameObject.GetComponent<ActorController>().Activate();
		}
	}
}
