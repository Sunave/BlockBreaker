using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;

	private Ball ball;

	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	void Update () {
		if (!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}

	void MoveWithMouse () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, this.transform.position.z);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}

	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, this.transform.position.z);
		float ballPos = ball.transform.position.x;
		paddlePos.x = Mathf.Clamp(ballPos, 0.5f, 15.5f);
		this.transform.position = paddlePos;
	}
}
