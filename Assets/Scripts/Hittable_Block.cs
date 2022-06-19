using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hittable_Block : MonoBehaviour
{
    [SerializeField]  //alows you to customize the actions that happen when the block is hit
    private UnityEvent _hit;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Player_Move>(); // check if object that collided with block has playermove script
        if (player && other.contacts[0].normal.y > 0) { // check if block has been hit from below
            _hit?.Invoke();  //invoke the action start inside the hit variable
            // in unity, I set the action to be assigned to a bool, which deactivates the game object when it is hit.
        }
    }
}