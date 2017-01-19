using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour {
	Rigidbody2D rb;
	Animates animates;

	public float speed;
	public bool canMove;
	public int direction;

	float actualSpeed;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		animates = GetComponent<Animates>();
		actualSpeed = speed;
	}

	public void ReceiveInput (float horizontal, float vertical) {
		int newDirection = GetDirectionInt(horizontal, vertical);
		ProcessMovement(newDirection);
	}

	int GetDirectionInt (float horizontal, float vertical) {
		if (vertical == 1) return 0;
		if (horizontal == 1) return 1;
		if (vertical == -1) return 2;
		if (horizontal == -1) return 3;
		return -1;
	}

	public void ProcessMovement (int newDirection) {
		if (canMove && newDirection >= 0) {
			direction = newDirection;
			animates.Direction(direction);
			animates.Moving(true);
			Move(direction);
		} else {
			animates.Moving(false);
		}
	}

	void Move (int direction) {
		Vector2 movement = GetMovementVector(direction);
		rb.AddForce(movement * actualSpeed);
	}

	Vector2 GetMovementVector (int newDirection) {
		Vector2 movementVector = new Vector2(0, 0);
		if (newDirection == 0) movementVector = new Vector2(0, 1);
		if (newDirection == 1) movementVector = new Vector2(1, 0);
		if (newDirection == 2) movementVector = new Vector2(0, -1);
		if (newDirection == 3) movementVector = new Vector2(-1, 0);
		return movementVector;
	}

	public void Lumber (float weight) {
		actualSpeed -= weight;
	}

	public void UnLumber () {
		actualSpeed = speed;
	}
}
