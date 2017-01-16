using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrubStatus : EnemyStatus
{
	private EnemyMovement enemyMovement;

	public override void Activate ()
	{
		enemyMovement = this.GetComponent<EnemyMovement>();
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "Player" || collider.tag == "Weapon")
		{
			enemyMovement.CanMove = true;
		}
	}
}
