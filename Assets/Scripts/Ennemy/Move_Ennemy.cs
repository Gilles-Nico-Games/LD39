using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Ennemy : MonoBehaviour {

    public int ennemySpeed = 10;
    public int ennemyJumpPower = 1250;

    public bool facingRight = true;
    public bool isGrounded;

    // Update is called once per frame
    void Update () {

        //Gestion des la physiques
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(ennemySpeed, gameObject.GetComponent<Rigidbody>().velocity.y, 0);
    }

    void FlipEnnemy()
    {
        facingRight = !facingRight;
        Vector3 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnCollisionEnter(Collision collider)
    {
        Debug.Log("Player has collided with : " + collider.collider.tag);
        if (collider.gameObject.tag == "colliderGround")
        {
            isGrounded = true;
        }
    }
}
