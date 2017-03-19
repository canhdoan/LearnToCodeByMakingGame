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

public class Projectile : MonoBehaviour
{
	public float projectileSpeed = 15.0f;
	public float Damage { get; set; }
	// Start is called when this script is enable on the scene, just before
	// the update function and only at the first time. This method is
	// provided for initialization.
	void Start ()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, projectileSpeed);

		Damage = 100.0f;
	}

	public void Hit()
	{
		Destroy(gameObject);
	}
}

