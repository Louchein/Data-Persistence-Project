using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public string currentPlayerName = "";
    public string bestPlayerName = "";

    public int highestScore = 0;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateHighestScore(int points) { 
        if (points > highestScore) {
            highestScore = points;
            bestPlayerName = currentPlayerName;
            SaveData();
        }
    }

    [System.Serializable]
    class SaveBestPlayerData {
        public string playerName;

        public int highestScore;
    }

    public void SaveData() {
        SaveBestPlayerData data = new SaveBestPlayerData();
        data.playerName = currentPlayerName;
        data.highestScore = highestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveBestPlayerData data = JsonUtility.FromJson<SaveBestPlayerData>(json);

            bestPlayerName = data.playerName;
            highestScore = data.highestScore;
        }
    }
}
