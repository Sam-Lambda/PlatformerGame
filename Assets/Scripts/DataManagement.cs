using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class DataManagement : MonoBehaviour
{
    public static DataManagement dataManagement;

    public int highScore;

    void Awake () {  // is this the same as Start?
        if (dataManagement == null) {
            DontDestroyOnLoad (gameObject);  // don't destroy game object
            dataManagement = this;
        } else if (dataManagement != this) {
            Destroy (gameObject);  // so if a save file doesn't exist, make the current state the save, otherwise destroy the current save?

        }
    }

    public void SaveData () {
        BinaryFormatter BinForm = new BinaryFormatter ();  // creates a bin formatter
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");  // creates file
        gameData data = new gameData();  // creates container for data
        data.highScore = highScore;
        BinForm.Serialize (file, data);  // Seralizes 
        file.Close();  // closes file

    }

    public void LoadData () {
        if (File.Exists (Application.persistentDataPath + "/gameInfo.dat")) {
            // then load it, otherwise don't
            BinaryFormatter BinForm = new BinaryFormatter ();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);  // find out what FileMode.Append does
            gameData data = (gameData)BinForm.Deserialize (file);  // decrypts the binary
            file.Close();
            highScore = data.highScore;
        }
        
    }

}

[Serializable]  // this straight up tells unity this is data to be saved
class gameData {  // when we save data we will be saving/loading from this class.

    public int highScore;  // not the same var as above

}
