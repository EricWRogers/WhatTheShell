using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMovement : MonoBehaviour {

	public LayerMask enemyMask;
	public float speed;
	[SerializeField]
	private bool isGrounded;
	Rigidbody2D myBody;
	Transform myTrans;
	float myWidth;
	
	// Use this for initialization
	void Start () {
		myTrans = this.transform;
		myBody = this.GetComponent<Rigidbody2D>();
		myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
		Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
		isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down);

		if(!isGrounded)
		{
			Vector3 currRot = myTrans.eulerAngles;
			currRot.y +=  180;
			myTrans.eulerAngles = currRot;
			speed = speed * -1;
		}
		//Always move forward
		Vector2 myVel = myBody.velocity;
		myVel.x = speed;
		myBody.velocity = myVel;
	}
}
