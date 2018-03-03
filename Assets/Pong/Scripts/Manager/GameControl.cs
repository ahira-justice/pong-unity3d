using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Difficulty {
    EASY, MEDIUM, HARD
}

[Serializable]
class GameData {
    public int playerID;
    public Difficulty difficulty;
}

public class GameControl : MonoBehaviour {
    public static GameControl control;

    public static int playerID;
    public static Difficulty difficulty;
    
    void OnEnable(){
        Load("gamedata.dat");
    }

    void OnDisable(){
        Save("gamedata.dat");
    }

    private void Awake(){
        if (control == null){
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
            Destroy(gameObject);
    }

    public void Save(string filename){
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;

        if (!File.Exists(Application.persistentDataPath + "/" + filename))
            file = File.Create(Application.persistentDataPath + "/" + filename);
        else
            file = File.Open(Application.persistentDataPath + "/" + filename, FileMode.Open);

        GameData data = new GameData();

        data.playerID = playerID;
        data.difficulty = difficulty;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load(string filename){
        if (File.Exists(Application.persistentDataPath + "/" + filename)){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + filename, FileMode.Open);

            GameData data = (GameData)bf.Deserialize(file);

            playerID = data.playerID;
            difficulty = data.difficulty;

            file.Close();
        }
    }
}