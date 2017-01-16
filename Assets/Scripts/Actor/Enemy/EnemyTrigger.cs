using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
	private EnemyAttack enemyAttack;
	private ActorMovement actorMovement;

	[SerializeField] float triggerDelay;
	[SerializeField] bool triggerActive;

	void Start ()
	{
		enemyAttack = transform.parent.GetComponent<EnemyAttack>();
		actorMovement = transform.parent.GetComponent<ActorMovement>();
	}

	void Update ()
	{
		SetDirection(actorMovement.Direction);
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "Player")
		{
			StartCoroutine(TriggerCoroutine());
		}
	}

	IEnumerator TriggerCoroutine ()
	{
		yield return new WaitForSeconds(triggerDelay);

		if (triggerActive)
		{
			enemyAttack.RecieveAttackInput(true);
		}
	}

	void SetDirection (int direction)
	{
		if (direction == 0) transform.localPosition = new Vector2(0, 1);
		if (direction == 1) transform.localPosition = new Vector2(1, 0);
		if (direction == 2) transform.localPosition = new Vector2(0, -1);
		if (direction == 3) transform.localPosition = new Vector2(-1, 0);
	}

	public bool TriggerActive {
		get { return triggerActive; }
		set { triggerActive = value; }
	}
}
