using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle _paddle;
	private bool _hasStarted = false;
	private Vector3 _paddleToBall;
	private Transform _thisTransform;
	private Rigidbody2D _thisRigidbody;
	private AudioSource _collideAudio;

	// Use this for initialization
	void Start () 
	{
		_paddle = FindObjectOfType<Paddle>();

		_thisTransform = transform;
		_paddleToBall = _thisTransform.position - _paddle.transform.position;

		_thisRigidbody = GetComponent<Rigidbody2D>();

		_collideAudio = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!_hasStarted) 
		{
			// lock ball on paddle
			_thisTransform.position = _paddle.transform.position + _paddleToBall;
			if (Input.GetMouseButtonUp(0)) 
			{
				// lauch game
				_hasStarted = true;
				_thisRigidbody.velocity = new Vector2(2.0f, 10.0f);
			}
		}
	}

	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnCollisionEnter2D(Collision2D other)
	{
		Vector2 tweak = new Vector2(Random.Range(0.0f, 0.2f), Random.Range(0.0f, 0.2f));
		if (_hasStarted)
		{
			_thisRigidbody.velocity += tweak;
			_collideAudio.Play();
		}
	}
}
