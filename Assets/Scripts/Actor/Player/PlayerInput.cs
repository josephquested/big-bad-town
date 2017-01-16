using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
	private PlayerMovement playerMovement;
	private PlayerAttack playerAttack;

	void Start ()
	{
		playerMovement = this.GetComponent<PlayerMovement>();
		playerAttack = this.GetComponent<PlayerAttack>();
	}

	void FixedUpdate ()
	{
		GetMovementInput();
		GetAttackInput();
	}

	void GetMovementInput ()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		playerMovement.RecieveMovementInput(horizontal, vertical);
	}

	void GetAttackInput ()
	{
		bool attack = Input.GetButtonDown("Attack");
		playerAttack.RecieveAttackInput(attack);
	}
}
