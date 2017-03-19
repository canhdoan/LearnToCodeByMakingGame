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
/// SpawnPoint
/// </summary>
public class SpawnPoint : MonoBehaviour
{
	/// <summary>
	/// Callback to draw gizmos that are pickable and always drawn.
	/// </summary>
	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, 1.0f);
	}
}
