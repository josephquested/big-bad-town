using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : ActorStatus
{
	public override void Die ()
	{
		spriteRenderer.enabled = false;
		actorCollider.enabled = false;
		Respawn();
	}

	void Respawn () {
		Health = 9;
		spriteRenderer.enabled = true;
		actorCollider.enabled = true;
		transform.position = Vector3.zero;
	}
}
