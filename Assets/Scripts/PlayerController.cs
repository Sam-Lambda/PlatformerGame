using UnityEngine;
 using System.Collections;
 
 public class PlayerController : MonoBehaviour
 {
     private Rigidbody2D rb2d; // Store the Players RigidBody Component in the variable rb2d
     public float maxSpeed = 10f; // this is simply to let you mess with the player speed easily
     bool facingRight = true; // this will be used for the direction of the player while moving
     bool onGround; // used for jumping
     // Use this for initialization
     void Awake()
     {
         rb2d = GetComponent<Rigidbody2D>(); // Hooks into the RigidBody Component
     }
 
     //FixedUpdate is called at a fixed interval and is independent of frame rate.
     void Update()
     {
         float move = Input.GetAxis("Horizontal");
         //Store the current horizontal input in the float moveHorizontal.
         if (move != 0)
            GetComponent<Animator>().SetBool("isRunning", true);
         else
            GetComponent<Animator>().SetBool("isRunning", false);
         rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y); 
         
         // Set the Player GameObject's velocity to the Horizontal input of the player
 
         if (move > 0 && !facingRight) // If the player is moving right and is not already facing right
             Flip(); // Call the Flip Function
         else if (move < 0 && facingRight) // Same as Above for Moving Left
             Flip();
         if (Input.GetKeyDown("space") || Input.GetKeyDown("joystick button 2")) // if either Space or the A Button on a controller is pressed
         {
             if (onGround == true) // And if the player is on the Ground
                 {
                 rb2d.velocity = new Vector2(rb2d.velocity.x, 5); // Give the player Upwards velocity of 4 (Jump)
             }
                 
         }
         
     }
     private void OnTriggerEnter2D (Collider2D floor) // On Entering the Collision of the Floor
     {
        onGround = true;
        Debug.Log("On the floor");
     }
     private void OnTriggerExit2D(Collider2D floor) // On exiting the Collision of the Floor
     {
        onGround = false;
        Debug.Log("Not On the floor");
     }
 
 
     void Flip()
     {
         facingRight = !facingRight;
         Vector3 Scale = transform.localScale;
         Scale.x *= -1; // Scale.x -1 Flips the Character, making them change direction
         transform.localScale = Scale; // set the characters scale to this new flipped scale
     }
 }