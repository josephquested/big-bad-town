using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : ActorAttack
{
	[SerializeField] private bool passiveAttack;
	[SerializeField] private bool triggerAttack;
	[SerializeField] private Weapon passiveWeapon;
	[SerializeField] private EnemyTrigger enemyTrigger;

	public bool PassiveAttack
	{
		get { return passiveAttack; }
		set
		{
			passiveWeapon.PassiveAttack(value);
			passiveAttack = value;
		}
	}

	public bool TriggerAttack
	{
		get { return triggerAttack; }
		set
		{
			if (enemyTrigger != null)
			{
				enemyTrigger.TriggerActive = value;
				triggerAttack = value;
			}
		}
	}
}
