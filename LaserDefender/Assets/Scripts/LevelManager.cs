using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{

	void Awake() 
	{
		Debug.Log ("Level Manager Awake " + GetInstanceID ());
	}

	public void LoadLevel(string name)
	{
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene(name);
	}

	private void LoadNextLevel() 
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void LoseGame()
	{
		LoadLevel("Lose Scene");
	}

	public void QuitRequest()
	{
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

}
