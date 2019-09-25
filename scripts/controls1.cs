using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;


public class controls1 : MonoBehaviour {

	public  movement11 controller;
	public Animator  animator;
	float hmove = 0f;
	public float speed = 40f;
	bool jump =false;
	bool crouch =false;
	public Rigidbody2D rb;
	public Text scoreee;
	int count = 0;
	int count1 = 0;

	// Use this for initialization
	void Start () {
		scoreee.enabled = false;
		Debug.Log(animator.GetBool("isJUMPING"));

	}

	// Update is called once per frame
	void Update () {
		
		hmove = (Input.GetAxisRaw ("Horizontal")) * speed ;	

		animator.SetFloat("Speed",Mathf.Abs(hmove));


		if (Input.GetKey ("up")) {
			jump = true;
			animator.SetBool ("isJUMPING", true);

		}

		if(Input.GetKeyDown("down")) { 
			
			crouch = true;
			animator.SetBool ("isCROUCH", crouch);
		}

		if(Input.GetKeyUp("down")) { 			
			crouch = false;
			animator.SetBool ("isCROUCH", crouch);}
	}



	
	

	public void OnLanding()
	{
		animator.SetBool ("isJUMPING", false);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "coins"){
			count1++;
			
			Debug.Log("COINS");
		Destroy(col.gameObject);
		}


		if(col.tag == "gems"){
			
			count++;
			Debug.Log(count);
			if(count == 2){
				scoreee.enabled = true;
				scoreee.text = $"GAME OVER!!!\n COINS collected: {count1}\nGEMS collected : {count}";}
			Debug.Log("gems"); 
			Destroy(col.gameObject);
		}
	}
	

	void FixedUpdate()
	{
		controller.Move(hmove * Time.deltaTime, crouch, jump);
		jump = false;


	}
}
