////////////////////////////////////////////////////////////////////////////////
// Copyright (C) 2017 AsNet Co., Ltd.
// All Rights Reserved. These instructions, statements, computer
// programs, and/or related material (collectively, the "Source")
// contain unpublished information proprietary to AsNet Co., Ltd
// which is protected by US federal copyright law and by
// international treaties. This Source may NOT be disclosed to
// third parties, or be copied or duplicated, in whole or in
// part, without the written consent of AsNet Co., Ltd.
////////////////////////////////////////////////////////////////////////////////
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
	public GameObject projectile;
	public float shortPerSecond = 0.5f;
	public float health = 150.0f;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		float prob = shortPerSecond*Time.deltaTime;
		if (Random.value < prob)
			Fire();
	}

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		Projectile laser = other.gameObject.GetComponent<Projectile>();
		if (laser)
		{
			health -= laser.Damage;
			laser.Hit();

			if (health <= 0.0f)
			{
				Destroy(gameObject);
			}
		}
	}

	void Fire()
	{
		GameObject laser = (GameObject)Instantiate(projectile, transform.position + Vector3.down, Quaternion.identity);
	}
}

