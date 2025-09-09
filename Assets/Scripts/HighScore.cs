using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
    static private Text _UI_TEXT;
    static private int _SCORE = 1000;

    private Text txtCom; // reference to this object's text component

    void Awake() {
        _UI_TEXT = GetComponent<Text>();

        // If HighScore exists set SCORE
        if (PlayerPrefs.HasKey("HighScore")) {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }

        // Set HighScore in PlayerPrefs to high score
        PlayerPrefs.SetInt("HighScore", SCORE);
    }

    static public int SCORE {
        get { return _SCORE; }
        private set {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);
            if (_UI_TEXT != null) {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry) {
        // Set _SCORE if new score is higher
        if (scoreToTry <= SCORE) return;
        SCORE = scoreToTry;
    }

    // This section allows resetting HighScore in PlayerPrefs
    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    void OnDrawGizmos() {
        if (resetHighScoreNow) {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore has been reset to 1,000.");
        }
    }

}
