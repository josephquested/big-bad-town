using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : ActorStatus
{
	private EnemyAttack enemyAttack;
	private Vector2 spawnLocation;
	private int spawnDirection;

	void Start ()
	{
		enemyAttack = this.GetComponent<EnemyAttack>();
		spawnLocation = transform.position;
		spawnDirection = actorMovement.Direction;
	}

	void Reset ()
	{
		actorMovement.CanMove = false;
		actorMovement.Direction = spawnDirection;
		transform.position = spawnLocation;
		enemyAttack.PassiveAttack = true;
		enemyAttack.TriggerAttack = true;
		Respawn();
	}

	public virtual void Activate ()
	{
		actorMovement.CanMove = true;
	}

	void Respawn ()
	{
		Health = BaseHealth;
		spriteRenderer.enabled = true;
		actorCollider.enabled = true;
	}

	public override void Die ()
	{
		StartCoroutine(DeathCoroutine(1.5f));
	}

	IEnumerator DeathCoroutine (float duration)
	{
		actorMovement.CanMove = false;
		enemyAttack.PassiveAttack = false;
		enemyAttack.TriggerAttack = false;
		enemyAttack.StopAttack();

		for (float i = 0; i < duration; i++)
		{
			spriteRenderer.color = Color.red;
			yield return new WaitForSeconds(0.1f);
			spriteRenderer.color = Color.black;
			yield return new WaitForSeconds(0.1f);
			spriteRenderer.color = Color.white;
		}

		actorCollider.enabled = false;
		spriteRenderer.enabled = false;
	}
}
