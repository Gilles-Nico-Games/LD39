using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Player : MonoBehaviour {

    public int playerSpeed = 10;
    public int playerJumpPower = 1250;

    public bool facingRight = true;
    public bool isGrounded;

    private float moveX;

	
	// Update is called once per frame
	void Update () {
        PlayerMove();

	}

    void PlayerMove()
    {
        //Gestion des controles
        moveX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }
        //Gestion Animations

        //Gestion de la direction du players
        if(moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        } else if (moveX > 0.0f && facingRight == true) {
            FlipPlayer();
        }
        //Gestion des la physiques
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(moveX * playerSpeed, gameObject.GetComponent<Rigidbody>().velocity.y, 0);

    }

    void Jump()
    {
        //Gestion du saut
        GetComponent<Rigidbody>().AddForce(Vector3.up * playerJumpPower);
        isGrounded = false;
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector3 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnCollisionEnter(Collision collider)
    {
        Debug.Log("Player has collided with : " + collider.collider.tag);
        if(collider.gameObject.tag == "colliderGround" )
        {
            isGrounded = true;
        }
    }
}
