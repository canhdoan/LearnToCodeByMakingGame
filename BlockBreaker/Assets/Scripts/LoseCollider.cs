using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private LevelManager _levelManager;


	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		_levelManager = FindObjectOfType<LevelManager>();
		if (!_levelManager)
			Debug.LogError("Level manager not exist on the scene.");
	}

	void OnTriggerEnter2D(Collider2D trigger)
	{
		_levelManager.LoseGame();
	}
}
