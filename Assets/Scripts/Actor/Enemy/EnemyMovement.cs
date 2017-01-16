using UnityEngine;
using System.Collections;

public class EnemyMovement : ActorMovement
{
	private bool movementCoroutine;

	[SerializeField] private Vector2 previousPosition;
	[SerializeField] private float minMovement;
	[SerializeField] private float maxMovement;

	void Start ()
	{
		rb = this.GetComponent<Rigidbody2D>();
		previousPosition = transform.position;
	}

	void Update ()
	{
		previousPosition = transform.position;
		if (!movementCoroutine)
		{
			movementCoroutine = true;
			StartCoroutine(MoveAtRandom());
		}
	}

	IEnumerator MoveAtRandom ()
	{
		int newDirection = Random.Range(0, 4);
		float duration = Random.Range(minMovement, maxMovement);

		while (duration >= 0)
		{
			duration -= 0.1f;
			ProcessMovement(newDirection);
			yield return new WaitForSeconds(0.01f);
		}

		movementCoroutine = false;
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.tag == "GameScreen" && collider.gameObject != transform.parent)
		{
			transform.position = previousPosition;
		}
	}
}
