using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Move : MonoBehaviour
{
    public int playerSpeed = 10;
    //private bool facingRight = false;  // this is so unity doesn't mess with these
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    public float distanceToBottomOfPlayer = 0.3426f;

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
        if (moveX != 0) {
            GetComponent<Animator>().SetBool("isRunning", true);
        } else {  // clearly this isn't perfect but its a placeholder
            GetComponent<Animator>().SetBool("isRunning", false);
        }

        // PLAYER DIRECTION
        if (moveX < 0.0f) {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f) {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        /*  // bad old school code
        // PLAYER DIRECTION
        if (moveX < 0.0f && facingRight == false){ // 'f' indicates that you want a float.
            flipPlayer ();
        }
        else if (moveX > 0.0f && facingRight == true){
            flipPlayer ();
        }
        */
        // PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }
    void Jump() {
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower); // obviously rigidbody2d is our player character
        isGrounded = false;
    }



    /*  // bad old school code
    void flipPlayer() {  // scale is var in unity, putting it to neg value will literally flip the asset
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale; // here we create vector2 var to interact with scale var in unity
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    */
        void PlayerRaycast () {  
        //TODO FIX DISGUSTING CODE



        /*
        // BAD CODE
        //  Ray UP
        RaycastHit2D rayUp = Physics2D.Raycast (transform.position, Vector2.up);  
        // if the distance between player and object is less than x, destroy object 
        if (rayUp != null && rayUp.collider != null && rayUp.distance < distanceToBottomOfPlayer && rayUp.collider.name == "Rock_Head") {
            Destroy (rayUp.collider.gameObject); 
        }
        */
        //  Ray DOWN
        // we want to shoot a ray down from the player and do something
        // we want bounce when hitting enemy
        RaycastHit2D rayDown = Physics2D.Raycast (transform.position, Vector2.down);  // this shoots a ray downwards
        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag == "enemy") {
            GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 1000);
            //Destroy (rayDown.collider.gameObject);  //you probably want this back instead of the below lines
            //  here we adjust the components for whatever the player lands on.
            rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 8;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
            rayDown.collider.gameObject.GetComponent<Enemy_Move> ().enabled = false;
            
        }
        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag != "enemy") {  // we can jump off boxes now
            isGrounded = true;
            //Debug.Log (rayDown.distance);
        }
        //  null checks are for an error for when the ray doesn't rayDown the ground (jumping over a gap)
    }
}
