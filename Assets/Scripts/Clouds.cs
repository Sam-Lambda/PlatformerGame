using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{

    public float speed = 1;
    private float xDir;

    // Start is called before the first frame update
    void Start()
    {
        xDir = transform.position.x;  // assigns the xdir as the x position of righthand game object
        
    }

    // Update is called once per frame
    void Update()
    {
        xDir -= Time.deltaTime * speed;  // reducing the x direction over time so the clouds move like real life :D
        transform.position = new Vector3 (xDir, transform.position.y, transform.position.z);
        if (transform.position.x < -60) {  // this will reset the clouds back to the front of the level so they loop instead of disappear
            transform.position = new Vector3 (30, transform.position.y, transform.position.z);
        }
        
    }
}
