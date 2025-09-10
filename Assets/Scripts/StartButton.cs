using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
    
    void Start() {
        // Connect button pressed event to StartGame function
        Button startButton = GetComponent<Button>();
        startButton.onClick.AddListener(StartGame);        
    }

    void StartGame() {
        // Load game scene
        SceneManager.LoadScene("_Scene_0");
    }
}
