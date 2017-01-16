using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	private Collider2D attackCollider;
	private SpriteRenderer spriteRenderer;
	private Transform parentTransform;

	[SerializeField] private Sprite[] sprites;
	[SerializeField] private int damage;
	[SerializeField] private int knockback;
	[SerializeField] private bool canDamageEnemies;

	void Start ()
	{
		attackCollider = this.GetComponent<Collider2D>();
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		parentTransform = transform.parent.transform;
	}

	void OnTriggerStay2D (Collider2D collider)
	{
		if (collider.tag == "Enemy" && !canDamageEnemies) return;
		if (collider.tag == "Enemy" || collider.tag == "Player")
		{
			ActorStatus status = collider.gameObject.GetComponent<ActorStatus>();
			if (!status.Invulnerable)
			{
				status.Damage(damage);
				Knockback(collider);
			}
		}
	}

	void Knockback (Collider2D collider)
	{
		Vector2 diff = (collider.transform.position - parentTransform.position).normalized;
		Vector2 direction = new Vector2(Mathf.Round(diff.x), Mathf.Round(diff.y));
		collider.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * knockback);
	}

	public void AttackInDirection (int direction)
	{
		SetDirection(direction);
		attackCollider.enabled = true;
		spriteRenderer.enabled = true;
	}

	public void PassiveAttack (bool value)
	{
		attackCollider.enabled = value;
	}

	public void StopAttack ()
	{
		attackCollider.enabled = false;
		spriteRenderer.enabled = false;
	}

	void SetDirection (int direction)
	{
		spriteRenderer.sprite = sprites[direction];
		if (direction == 0) transform.localPosition = new Vector2(0, 1);
		if (direction == 1) transform.localPosition = new Vector2(1, 0);
		if (direction == 2) transform.localPosition = new Vector2(0, -1);
		if (direction == 3) transform.localPosition = new Vector2(-1, 0);
	}
}
