using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusText : MonoBehaviour {
    private static Text _uiText;
    private static int _status;

    void Awake() {
        _status = 1;
        _uiText = GetComponent<Text>();
    }
    
    static public int Status {
        get { return _status; }
        set {
            // Update text based on input
            // if <0 set state to game over
            if (value < 0) {
                _uiText.text = "Game Over";
            }
            else {
                _uiText.text = "Round " + value.ToString();
            }

            _status = value;
        }
    }
}
