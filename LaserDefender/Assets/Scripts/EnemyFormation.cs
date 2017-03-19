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
/// EnemyFormation
/// </summary>
public class EnemyFormation : MonoBehaviour
{
	public GameObject enemyPrefab;
	public float width = 10.0f;
	public float height = 5.0f;
	public float speed = 5.0f;
	public float spawnDelay = 0.5f;

	private bool _movingRight = true;
	private float _minX;
	private float _maxX;
	// Start is called when this script is enable on the scene, just before
	// the update function and only at the first time. This method is
	// provided for initialization.
	void Start ()
	{
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0,0, distanceToCamera));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1,0, distanceToCamera));
		_minX = leftBoundary.x;
		_maxX = rightBoundary.x;

		SpawnEnemies();
	}

	/// Update is called once per frame
	void Update ()
	{
		MoveUpdating();

		if (AllEnemyDead())
		{
			SpawnUntilFull();
		}
	}

	void MoveUpdating()
	{
		if (_movingRight)
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		else
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		float leftEdgeOfFormation = transform.position.x - (0.5f*width);
		float rightEdgeOfFormation = transform.position.x + (0.5f*width);
		if (leftEdgeOfFormation < _minX)
		{
			_movingRight = true;
		}
		else if (rightEdgeOfFormation > _maxX)
		{
			_movingRight = false;
		}
	}

	void SpawnEnemies()
	{
		foreach(Transform child in transform)
		{
			GameObject newEnemy = (GameObject)Instantiate(enemyPrefab, child, false);
			newEnemy.transform.localPosition = Vector3.zero;
		}
	}

	void SpawnUntilFull()
	{
		Transform freePosition = NextFreePosition();
		if (freePosition)
		{
			GameObject newEnemy = (GameObject)Instantiate(enemyPrefab, freePosition, false);
			newEnemy.transform.localPosition = Vector3.zero;
		}

		if (NextFreePosition())
		{
			Invoke("SpawnUntilFull", spawnDelay);
		}
	}

	Transform NextFreePosition()
	{
		foreach(Transform childPositionGameObject in transform)
		{
			if (childPositionGameObject.childCount == 0)
				return childPositionGameObject;
		}
		return null;
	}

	bool AllEnemyDead()
	{
		foreach(Transform childPositionGameObject in transform)
		{
			if (childPositionGameObject.childCount > 0)
				return false;
		}
		return true;
	}

	/// <summary>
	/// Callback to draw gizmos that are pickable and always drawn.
	/// </summary>
	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
	}
}

