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


/// <summary>
/// PlayerController
/// </summary>
public class PlayerController : MonoBehaviour
{
	private Transform _thisTransform;
	[SerializeField] private float _speed = 1.0f;

	// Variables to clamp movement function
	private float _minX;
	private float _maxX;
	[SerializeField] private float _padding = 1.0f;

	public GameObject projectTile;
	public float fireRepeatRate;

	public float health = 250.0f;

	// Start is called when this script is enable on the scene, just before
	// the update function and only at the first time. This method is
	// provided for initialization.
	void Start ()
	{
		_thisTransform = transform;
		// Catch min/max x from camera's ViewportToWorldPoint function
		float distance = _thisTransform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		_minX = leftMost.x + _padding;
		_maxX = rightMost.x - _padding;
	}
	/// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			InvokeRepeating("Fire", 0.0001f, fireRepeatRate);
		if (Input.GetKeyUp(KeyCode.Space))
			CancelInvoke("Fire");
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			OnMovingLeft();
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			OnMovingRight();
		}
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

	private void Fire()
	{
		Instantiate(projectTile.gameObject, transform.position, Quaternion.identity);
	}

	private void OnMovingLeft()
	{
		Vector3 target = _thisTransform.position + Vector3.left;
		_thisTransform.position = StepToTarget(target);
	}

	private void OnMovingRight()
	{
		Vector3 target = _thisTransform.position + Vector3.right;
		_thisTransform.position = StepToTarget(target);
	}
	
	private Vector3 StepToTarget(Vector3 target)
	{
		float step = _speed*Time.deltaTime;
		Vector3 newPos = Vector3.MoveTowards(_thisTransform.position, target, step);
		newPos.x = Mathf.Clamp(newPos.x, _minX, _maxX);
		return newPos;
	}
}
