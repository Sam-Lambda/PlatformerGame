using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{

    public int health;
    public bool hasDied;
    
    // Start is called before the first frame update
    void Start()
    {
        hasDied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -7) {
            hasDied = true;
        }
        if (hasDied == true) {
            StartCoroutine ("Die");
        }
    }
    
    IEnumerator Die () {
        SceneManager.LoadScene ("SampleScene"); // what we're doing here is we're just forcing the game to replay.
        yield return null; // we always have to return so we return nul for now
    }
}
