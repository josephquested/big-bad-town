using UnityEngine;
using System.Collections;

public class ActorMovement : MonoBehaviour
{
	protected Rigidbody2D rb;
	private bool moving;

	[SerializeField] private bool canMove;
	[SerializeField] private float speed;
	[SerializeField] private int direction;

	void Start ()
	{
		rb = this.GetComponent<Rigidbody2D>();
	}

	public void RecieveMovementInput (float horizontal, float vertical)
	{
		int newDirection = GetDirectionInt(horizontal, vertical);
		ProcessMovement(newDirection);
	}

	public void ProcessMovement (int newDirection)
	{
		if (newDirection == 5 || !canMove)
		{
			moving = false;
		}
		else
		{
			moving = true;
			direction = newDirection;
			Move(direction);
		}
	}

	void Move (int direction)
	{
		Vector2 movement = GetMovementVector(direction);
		rb.AddForce(movement * speed);
	}

	int GetDirectionInt (float horizontal, float vertical)
	{
		if (vertical == 1) return 0;
		if (horizontal == 1) return 1;
		if (vertical == -1) return 2;
		if (horizontal == -1) return 3;
		else return 5;
	}

	Vector2 GetMovementVector (int newDirection)
	{
		Vector2 movementVector = new Vector2(0, 0);
		if (newDirection == 0) movementVector = new Vector2(0, 1);
		if (newDirection == 1) movementVector = new Vector2(1, 0);
		if (newDirection == 2) movementVector = new Vector2(0, -1);
		if (newDirection == 3) movementVector = new Vector2(-1, 0);
		return movementVector;
	}

	public int Direction
	{
		get { return direction; }
		set { direction = value; }
	}

	public bool Moving
	{
		get { return moving; }
	}

	public bool CanMove
	{
		get { return canMove; }
		set { canMove = value; }
	}
}
