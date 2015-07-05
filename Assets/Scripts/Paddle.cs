using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public float minX, maxX;

	private Ball ball;

	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	void Update () {
		Move();
	}

	void Move () {
		float posInBlocks;
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, this.transform.position.z);

		if (autoPlay) { 
			posInBlocks = ball.transform.position.x;
		} else {
			posInBlocks = Input.mousePosition.x / Screen.width * 16;
		}

		paddlePos.x = Mathf.Clamp(posInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}
	
}
