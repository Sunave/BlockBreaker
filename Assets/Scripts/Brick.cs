using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;

	private bool isBreakable;
	private int timesHit;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		isBreakable = this.tag == "Breakable";

		if (isBreakable) breakableCount++;

		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collider) {
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.5f);
		if (isBreakable) {
			HandleHits();
		}
	}

	void HandleHits () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (maxHits <= timesHit) {
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy (gameObject);
		} else {
			LoadSprites();
		}
	}

	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Brick sprite missing!");
		}
	}

	void PuffSmoke() {
		GameObject puff = Instantiate(smoke, this.transform.position, Quaternion.identity) as GameObject; 
		puff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
}
