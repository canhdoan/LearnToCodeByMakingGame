using UnityEngine;

public class Brick : MonoBehaviour {

	public static int BrickCount = 0;
	private int _maxHits = 0;
	private int _timesHit = 0;
	private bool _isBreakable = false;
	[SerializeField] private AudioClip _crackSound;

	[SerializeField] private Sprite[] _hitSprites;
	private SpriteRenderer _thisSpriteRenderer;

	private LevelManager _levelManager;

	// Use this for initialization
	void Start ()
	{
		_isBreakable = CompareTag("Breakable");
		if (_isBreakable)
			BrickCount++;

		_timesHit = 0;
		_thisSpriteRenderer = GetComponent<SpriteRenderer>();

		_levelManager = FindObjectOfType<LevelManager>();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		AudioSource.PlayClipAtPoint(_crackSound, transform.position, 0.85f);
		if (_isBreakable)
			HandleHits();
	}

	void HandleHits()
	{
		_maxHits = _hitSprites.Length + 1;
		if (++_timesHit >= _maxHits)
		{
			BrickCount--;
			_levelManager.BrickDestroyed();
			Destroy(this.gameObject);
		}
		else
		{
			ReloadSprite();
		}
	}

	void ReloadSprite()
	{
		int spriteIndex = _timesHit - 1;
		if (_hitSprites[spriteIndex] == null)
			return;

		_thisSpriteRenderer.sprite = _hitSprites[spriteIndex];
	}
}
