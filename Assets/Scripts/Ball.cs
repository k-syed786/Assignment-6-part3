using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public Rigidbody2D rigidBody;
	public Transform paddle;
	public float InitialBallSpeed;
    public bool isStarted;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
		rigidBody = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStarted)
        {
            transform.position = paddle.position;
        }

        if (Input.GetButtonDown("Fire1") && !isStarted)
        {
            isStarted = true;
            rigidBody.AddForce(Vector2.up * InitialBallSpeed);
        }
    }

	void OnCollisionEnter2D(Collision2D ball){

		if(ball.gameObject.CompareTag("Paddle")){
			Debug.Log("Ball hit Paddle");
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.paddleHit);
        }
			if(ball.gameObject.CompareTag("Block")){
                    Destroy(ball.gameObject);
                    Debug.Log("Ball hit Block");
                    SoundManager.Instance.PlayOneShot(SoundManager.Instance.blockHit);
        }
				if(ball.gameObject.CompareTag("panelTop")){
					Debug.Log("Ball hit Top Panel");
                    SoundManager.Instance.PlayOneShot(SoundManager.Instance.wallHit);
        }
					if(ball.gameObject.CompareTag("panelBottom")){
						Debug.Log("Ball hit Bottom Panel");
                        rigidBody.velocity = Vector2.zero;
                        isStarted = false;

        }
						if(ball.gameObject.CompareTag("panelLeft")){
							Debug.Log("Ball hit Left Panel");
                            SoundManager.Instance.PlayOneShot(SoundManager.Instance.wallHit);
        }
							if(ball.gameObject.CompareTag("panelRight")){
							Debug.Log("Ball hit Right Panel");
                            SoundManager.Instance.PlayOneShot(SoundManager.Instance.wallHit);
        }


	}
}
