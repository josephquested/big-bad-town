using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	MeleeAttack meleeAttack;
	RangedAttack rangedAttack;
	Moves moves;

	void Start () {
		moves = GetComponent<Moves>();
		meleeAttack = GetComponent<MeleeAttack>();
		rangedAttack = GetComponent<RangedAttack>();
	}

	void FixedUpdate () {
		MovementInput();
		AttackInput();
		ShootInput();
	}

	void MovementInput () {
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		moves.ReceiveInput(horizontal, vertical);
	}

	void AttackInput () {
		if (Input.GetButtonDown("Attack")) {
			meleeAttack.ReceiveInput();
		}
	}

	void ShootInput () {
		if (Input.GetButtonDown("Shoot")) {
			print("shoot input");
			rangedAttack.ReceiveInput();
		}
	}
}
