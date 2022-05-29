using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -7) {
            Die ();
        }
    }
    
    void Die () {
        SceneManager.LoadScene ("SampleScene"); // what we're doing here is we're just forcing the game to replay.
        // we always have to return so we return nul for now
    }
}
