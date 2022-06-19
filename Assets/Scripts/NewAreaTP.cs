using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAreaTP : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject sp1, sp2; // spawn points
    public static bool canTransport;  //for some reason this is bad design? investigate

    void start () {
        canTransport = true;
        sp1 = this.gameObject;
    }

    void OnTriggerEnter2D(Collider2D trig) {  // trig is item we are hitting
        if (canTransport == true) {
            trig.gameObject.transform.position = sp2.gameObject.transform.position;
            canTransport = false;
    }
    }
    void OnTriggerExit2D(Collider2D trig) {
        canTransport = true;    //why is this bugging
    }
}
