using UnityEngine;

public class Paddle : MonoBehaviour {

	private Transform thisTransform;
	private Ball _ball;

	[SerializeField] private bool _autoPlay = false;
	private float _minX = 0.5f;
	private float _maxX = 15.5f;

	// Use this for initialization
	void Start () 
	{
		thisTransform = transform;
		_ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_autoPlay)
			AutoPlay();
		else
			MoveWithMouse();
	}

	void AutoPlay()
	{
		Vector3 paddlePos = new Vector3 (0.5f, thisTransform.position.y, 0.0f);
		float ballPos = _ball.transform.position.x;
		paddlePos.x = Mathf.Clamp (ballPos, _minX, _maxX);
		thisTransform.position = paddlePos;
	}

	void MoveWithMouse()
	{
		Vector3 paddlePos = new Vector3 (0.5f, thisTransform.position.y, 0.0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16.0f;
		paddlePos.x = Mathf.Clamp (mousePosInBlocks, _minX, _maxX);
		thisTransform.position = paddlePos;
	}
}
