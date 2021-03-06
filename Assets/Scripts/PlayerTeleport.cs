using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{

    private GameObject currentTeleporter;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (currentTeleporter != null) {
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter")) {
        currentTeleporter = collision.gameObject;
    }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter")) {
        if (collision.gameObject == currentTeleporter) {
            currentTeleporter = null;
        }
        }
        
    }
}



    /*  // OLD CODE
    public GameObject sp1, sp2; // spawn points
    public static bool canTransport;  //for some reason this is bad design? investigate
    GameObject player = GameObject.FindGameObjectWithTag("Player");

    void start()
    {
        canTransport = true;
        sp1 = this.gameObject;
    }

    void OnTriggerEnter2D(Collider2D trig)
    {  // trig is item we are hitting
        if (canTransport == true)
        {
            // this is what you want to do in steps but you're too smart to get it right
                player.transform.Rotate(new Vector3(0, 90 * Time.deltaTime, 0));
                player.transform.position = new Vector3(0,0,2) * Time.deltaTime;
                trig.gameObject.transform.position = sp2.gameObject.transform.position;
            //player.transform.Rotate(new Vector3(0, 90 * Time.deltaTime, 0));
            //trig.gameObject.transform.position = sp2.gameObject.transform.position;  //og code
            canTransport = false;
        }
    }
    
    void OnTriggerExit2D(Collider2D trig) {
        canTransport = true;
    }
    */