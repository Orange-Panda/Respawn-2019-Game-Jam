using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit Properties")]
public class UnitProperties : ScriptableObject
{
	[Header("Unit Metadata")]
	public float health;

	[Header("Movement Properties")]
	public float speed;
	public float jumpStrength;
	public float fallStrength;
}
