using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangBarrelBox : MonoBehaviour {
	public GameScreen parentScreen;
	bool cooledDown = true;

	public GameObject barrelPrefab;
	public int direction;
	public float frequency;
	public float velocity;

	void Start () {
		parentScreen = transform.parent.gameObject.GetComponent<GameScreen>();
	}

	void Update () {
		if (parentScreen.screenActive) {
			if (cooledDown) {
				Spawn();
			}
		}
	}

	void Spawn () {
		var prefab = Instantiate(barrelPrefab, transform.position, transform.rotation);
		prefab.GetComponent<Rigidbody2D>().AddForce(GetVector(direction) * velocity);
		SetBarrelRotation(prefab);
		StartCoroutine(CooldownCoroutine());
	}

	IEnumerator CooldownCoroutine () {
		cooledDown = false;
		yield return new WaitForSeconds(frequency);
		cooledDown = true;
	}

	void SetBarrelRotation (GameObject barrel) {
		if (direction == 3) {
			barrel.transform.localEulerAngles = new Vector3(0, 180, 0);
		}
	}

	Vector2 GetVector (int direction) {
		if (direction == 0) return new Vector2(0, 1);
		if (direction == 1) return new Vector2(1, 0);
		if (direction == 2) return new Vector2(0, -1);
		return new Vector2(-1, 0);
	}
}
