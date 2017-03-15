using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance;

	void Awake() {
		Debug.Log ("Music Player Awake " + GetInstanceID ());
		if (instance != null) {
			Destroy (gameObject);
			Debug.Log ("Dupdate music player, destroy this");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
