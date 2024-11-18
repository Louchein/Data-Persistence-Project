using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainGame : MonoBehaviour {

    private Text bestScoreText = null;

    private void Awake() {
        bestScoreText = GameObject.FindWithTag("BestScore").GetComponent<Text>();
    }
    private void Start() {
        bestScoreText.text = "Best Score : " + GameManager.Instance.bestPlayerName + " : " + GameManager.Instance.highestScore; 
    }

}
