using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	public float speed;
	public float rightEdge;
	public float leftEdge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
	void Update()
	{
		MoveWithMouse();
	}

	void MoveWithMouse(){
		float horizontal = Input.GetAxis ("Horizontal");

		transform.Translate (Vector2.right * horizontal * Time.deltaTime * speed);

		if(transform.position.x < leftEdge){
			transform.position = new Vector2 (leftEdge, transform.position.y);
		}

		if(transform.position.x > rightEdge){
			transform.position = new Vector2 (rightEdge, transform.position.y);
		}
	}

	void OnCollisionEnter2D(Collision2D paddle){
		if(paddle.gameObject.CompareTag("Ball")){
			Debug.Log("Ball hit Paddle");
		}
}
}