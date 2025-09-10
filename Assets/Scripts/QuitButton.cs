using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    void Start()
    {
        // Connect button pressed event to QuitGame function
        Button quitButton = GetComponent<Button>();
        quitButton.onClick.AddListener(QuitGame);
    }

    void QuitGame() {
        // If in editor need to use a different function
        #if UNITY_STANDALONE
        Application.Quit();
        #endif
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
