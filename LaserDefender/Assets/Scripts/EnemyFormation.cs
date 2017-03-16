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
using System.Collections;
using System.Collections.Generic;

namespace Namespace.EnemyFormation
{
	/// <summary>
	/// EnemyFormation
	/// </summary>
	public class EnemyFormation : MonoBehaviour
	{
		#region Fields
		public GameObject enemyPrefab;

		public float width = 10.0f;
		public float height = 5.0f;
		public float speed = 5.0f;

		private bool _movingRight = true;
		private float _minX;
		private float _maxX;
		#endregion // Fields

		#region Methods

		#region MonoBehaviour's Functions
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

			foreach(Transform child in transform)
			{
				GameObject newEnemy = (GameObject)Instantiate(enemyPrefab, child, false);
				newEnemy.transform.localPosition = Vector3.zero;
			}
		}

		/// Update is called once per frame
		void Update ()
		{
			MoveUpdating();
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

		/// <summary>
		/// Callback to draw gizmos that are pickable and always drawn.
		/// </summary>
		void OnDrawGizmos()
		{
			Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
		}
		#endregion // MonoBehaviour's Functions

		#endregion // Methods
	}
}

