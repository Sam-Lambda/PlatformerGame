using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Move : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool facingRight = false;  // this is so unity doesn't mess with these
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;


    // Update is called once per frame
    //everything in here runs at every frame in the game, constantly updates.
    void Update() 
    {
        playerMove (); // calling below function
        PlayerRaycast ();
    }
    void playerMove() {
        // CONTROLS
        moveX = Input.GetAxis("Horizontal"); // 1 means the stick is pushed all the way to the right
        if (Input.GetButtonDown ("Jump") && isGrounded){
            Jump();
        }
        // ANIMATIONS
        // PLAYER DIRECTION
        if (moveX < 0.0f && facingRight == false){ // 'f' indicates that you want a float.
            flipPlayer ();
        }
        else if (moveX > 0.0f && facingRight == true){
            flipPlayer ();
        }
        // PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }
    void Jump() {
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower); // obviously rigidbody2d is our player character
        isGrounded = false;
    }
    void flipPlayer() {  // scale is var in unity, putting it to neg value will literally flip the asset
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale; // here we create vector2 var to interact with scale var in unity
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnCollisionEnter2D (Collision2D col){

        }

        void PlayerRaycast () {  // we want to shoot a ray down from the player and do something
        // we want bounce when hitting enemy
        RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down);  // this shoots a ray downwards
        if (hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag == "enemy") {
            GetComponent<Rigidbody2D>().AddForce (Vector2.up * 1000);
        }
        if (hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag != "enemy") {  // we can jump off boxes now
            isGrounded = true;
        }
        //  null checks are for an error for when the ray doesn't hit the ground (jumping over a gap)
    }
}
