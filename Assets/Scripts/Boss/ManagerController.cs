using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerController : MonoBehaviour {
	Rigidbody2D rb;
	Animator animator;
	GameScreen parentScreen;

	public float speed;

	public float minMovement;
	public float maxMovement;
	public bool canMove;
	public bool isMoving;

	public GameObject barrelPrefab;
	public bool attacking;
	public float attackCooldown;
	public float attackAnimation;
	public float barrelSpeed;

	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
		rb.interpolation = RigidbodyInterpolation2D.Extrapolate;
		parentScreen = transform.parent.GetComponent<GameScreen>();
	}

	void Update () {
		if (!parentScreen.screenActive) {
			Reset();
		} else {
			Active();
		}

		if (!isMoving && canMove){
			ProcessMovement();
		}

		if (!attacking && canMove) {
			StartCoroutine(AttackCoroutine());
		}
	}

	public void Active () {
		canMove = true;
	}

	void Reset () {
		canMove = false;
		ManagerStatus status = GetComponent<ManagerStatus>();
		status.health = status.maxHealth;
	}

	// movement

	void ProcessMovement () {
		int direction = 1;
		if (Random.Range(0, 2) == 0) {
			direction = 3;
		}
		float duration = Random.Range(minMovement, maxMovement);
		StartCoroutine(MovementCoroutine(direction, duration));
	}

	IEnumerator MovementCoroutine (int direction, float duration) {
		isMoving = true;
		Vector2 movementVector = GetMovementVector(direction);
		rb.AddForce(movementVector * speed);
		while (duration >= 0) {
			duration -= 0.1f;
			yield return new WaitForSeconds(0.01f);
		}
		isMoving = false;
	}

	Vector2 GetMovementVector (int direction) {
		if (direction == 1) return new Vector2(1, 0);
		if (direction == 3) return new Vector2(-1, 0);
		return new Vector2(0, 0);
	}

	// attack

	IEnumerator AttackCoroutine () {
		animator.SetBool("moving", false);
		animator.SetBool("attack", true);
		attacking = true;

		Attack();

		yield return new WaitForSeconds(attackAnimation);
		animator.SetBool("moving", true);
		animator.SetBool("attack", false);

		yield return new WaitForSeconds(attackCooldown);
		attacking = false;
	}

	void Attack () {
		Vector2 spawnPostion = new Vector2(transform.position.x, transform.position.y - 1.5f);
		var prefab = Instantiate(barrelPrefab, spawnPostion, transform.rotation);
		prefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1) * barrelSpeed);
		prefab.transform.localEulerAngles = new Vector3(0, 0, -90);
	}
}
