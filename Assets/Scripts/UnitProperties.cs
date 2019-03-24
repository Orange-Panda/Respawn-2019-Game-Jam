using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains data for the units.
/// </summary>
[CreateAssetMenu(menuName = "Unit Properties")]
public class UnitProperties : ScriptableObject
{
	[Header("Unit Metadata")]
	public float health;

	[Header("Movement Properties")]
	public float airSpeed;
	public float walkSpeed;
	public int jumps;
	public float jumpStrength;
	public float fallStrength;
	public float jumpRecoveryTime = 0.2f;

	[Header("")]
	public AudioClip jumpRecoverySound;
	public AudioClip groundJumpSound;
	public AudioClip airJumpSound;
	public AudioClip landSound;
	public AudioClip bounceSound;
	public AudioClip noJumpsSound;
}
