using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

	public void OnCollisionEnter2D(Collision2D block){
		if(block.gameObject.CompareTag("Ball")){
			Debug.Log("Ball hit Block");
		}
	}

}
