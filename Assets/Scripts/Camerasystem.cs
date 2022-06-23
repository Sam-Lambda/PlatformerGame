using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerasystem : MonoBehaviour
{

    private GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player"))  //if player exists..
        {  //if a player exists, focus camera on it
            player = GameObject.FindGameObjectWithTag("Player"); // finds object with tag and associates it with variable above.
                                                                 // this tag we made through edit -> project settings -> tags and layers.
                                                                 // then found out it already exists.. so we got rid of it.
        }
    }

    // Update is called once per frame
    void Update() // when using camera systems late update is better? look into this later.
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
            float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
            // these restrict the camera from going on forever given the max and min values on the axis.

            gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
        }
    }
}
