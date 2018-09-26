using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMovement : MonoBehaviour {

	public LayerMask enemyMask;
	public float speed;
	Rigidbody2D myBody;
	Transform myTrans;
	float myWidth;
	
	// Use this for initialization
	void Start () {
		myTrans = this.transform;
		myBody = the.GetComponent<Rigidbody2D>();
		myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
		//Debug.DrawLine();

		//Always move forward
		Vector2 myVel = myBody.velocity;
		myVel.x = speed;
		myBody.velocity = myVel;
	}
}
