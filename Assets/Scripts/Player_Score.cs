using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // this is for the Text bug below

public class Player_Score : MonoBehaviour
{

    private float timeLeft = 120;  // public would've stayed with the inspected value (ion the inspector) on unity and we dont want that
    public int playerScore = 0;
    public GameObject timeLeftUI;  // this is so we can attach the object to the script?
    public GameObject playerScoreUI;


    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;  // ticks our timer down by seconds
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);  // why is text not working?
        if (timeLeft < 0.1f) {
            SceneManager.LoadScene ("SampleScene");
        }
    }

    void OnTriggerEnter2D (Collider2D trig){
        //Debug.Log ("Touched the end of the level");
        if (trig.gameObject.name == "EndLevel") {  // you should avoid using .name
        CountScore ();
        }
        if (trig.gameObject.name == "Apple") {
            playerScore += 10;
            Destroy (trig.gameObject);
        }
    }

    void CountScore () {
        playerScore = playerScore + (int)(timeLeft * 10);
        Debug.Log (playerScore);
    }
}
