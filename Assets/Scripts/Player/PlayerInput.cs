using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	MeleeAttack meleeAttack;
	Moves moves;

	void Start () {
		moves = GetComponent<Moves>();
		meleeAttack = GetComponent<MeleeAttack>();
	}

	void FixedUpdate () {
		MovementInput();
		AttackInput();
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
}
