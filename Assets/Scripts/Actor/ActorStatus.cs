using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorStatus : MonoBehaviour
{
	[SerializeField] private int baseHealth;
	[SerializeField] private int health;
	[SerializeField] private bool invulnerable;
	[SerializeField] private float invulnerableDuration;

	protected Collider2D actorCollider;
	protected SpriteRenderer spriteRenderer;
	protected ActorMovement actorMovement;
	protected ActorAudio actorAudio;

	void Awake ()
	{
		DontDestroyOnLoad(transform.gameObject);
		actorMovement = this.GetComponent<ActorMovement>();
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		actorCollider = this.GetComponent<Collider2D>();
		actorAudio = this.GetComponent<ActorAudio>();
	}

	public void Damage (int damage)
	{
		if (invulnerable) return;
		health -= damage;
		actorAudio.Hurt();
		StartCoroutine(InvulnerableCoroutine(invulnerableDuration));

		if (health <= 0)
		{
			Die();
		}
	}

	public virtual void Die ()
	{
		spriteRenderer.enabled = false;
		actorCollider.enabled = false;
	}

	public void DieForever ()
	{
		Destroy(gameObject);
	}

	IEnumerator InvulnerableCoroutine (float duration)
	{
		for (float i = 0; i < duration; i++)
		{
			Invulnerable = true;
			spriteRenderer.color = Color.red;
			yield return new WaitForSeconds(0.1f);
			spriteRenderer.color = Color.white;
			yield return new WaitForSeconds(0.1f);
		}
		Invulnerable = false;
	}

	public int Health
	{
		get { return health; }
		set { health = value; }
	}

	public int BaseHealth
	{
		get { return baseHealth; }
	}

	public bool Invulnerable
	{
		get { return invulnerable; }
		set { invulnerable = value; }
	}
}
