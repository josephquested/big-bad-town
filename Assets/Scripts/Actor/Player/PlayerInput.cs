using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	PlayerAttack playerAttack;
	Moves moves;

	void Start () {
		moves = GetComponent<Moves>();
		playerAttack = GetComponent<PlayerAttack>();
	}

	void FixedUpdate () {
		MovementInput();
		GetAttackInput();
	}

	void MovementInput () {
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		moves.ReceiveInput(horizontal, vertical);
	}

	void GetAttackInput () {
		bool attack = Input.GetButtonDown("Attack");
		playerAttack.RecieveAttackInput(attack);
	}
}
