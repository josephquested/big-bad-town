using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour {
	Vector2 previousPosition;
	Moves moves;

	public bool moving;
	public bool randomMovement;
 	public float minMovement;
 	public float maxMovement;

	void Start () {
		moves = GetComponent<Moves>();
	}

	void Update () {
		previousPosition = transform.position;

		if (!moving){
			if (randomMovement) {
				StartCoroutine(MoveAtRandom());
			}
		}
	}

	IEnumerator MoveAtRandom ()
	{
		int direction = Random.Range(0, 4);
		float duration = Random.Range(minMovement, maxMovement);
		moving = true;

		while (duration >= 0) {
			duration -= 0.1f;
			moves.ProcessMovement(direction);
			yield return new WaitForSeconds(0.01f);
		}

		moves.ProcessMovement(-1);
		moving = false;
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "GameScreen" && collider.gameObject != transform.parent) {
			transform.position = previousPosition;
		}
	}
}
