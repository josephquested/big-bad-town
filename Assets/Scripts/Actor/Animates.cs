using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animates : MonoBehaviour {
	Animator animator;
	public int direction;

	void Start () {
		animator = GetComponent<Animator>();
		animator.SetInteger("direction", direction);
		animator.speed = 0;
	}

	public void Direction (int newDirection) {
		direction = newDirection;
		animator.SetInteger("direction", direction);
	}

	public void Moving (bool isMoving) {
		if (isMoving) {
			animator.speed = 1;
		} else {
			animator.speed = 0;
		}
	}

	public void Attacking (bool isAttacking) {
		animator.SetBool("attacking", isAttacking);
	}
}
