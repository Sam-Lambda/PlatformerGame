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

    void Start () {
        //Just for testing
        DataManagement.dataManagement.LoadData();  // if all works, this is supposed to load in our highscore from any previous save.
        // To clarify, we're creating a serialized encrypted save file where we're getting our score, and we're sending in to that save file
        // then writing that out to an actual file that will stay there unless you delete the entire game off your system and then we're loading
        // that data.
    }


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
        Debug.Log("Data says high score is currently " +DataManagement.dataManagement.highScore);
        playerScore = playerScore + (int)(timeLeft * 10);
        DataManagement.dataManagement.highScore = playerScore + (int)(timeLeft * 10);
        DataManagement.dataManagement.SaveData ();
        Debug.Log("After adding score to DataManagement, Data says high score is currently " +DataManagement.dataManagement.highScore);

    }
}
