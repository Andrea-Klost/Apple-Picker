using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Basket : MonoBehaviour {
    public ScoreCounter scoreCounter;
    
    void Start()
    {
        // Find a GameObject named ScoreCounter in the scene
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get ScoreCounter script
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    void Update()
    {
       // Get current screen position of mouse
       Vector3 mousePos2d = Input.mousePosition;
       
       // The Camera's z position sets how far to push the mouse into 3D
       // Needs Main Camera to have MainCamera tag
       mousePos2d.z = -Camera.main.transform.position.z;
       
       // Convert point from 2D screen space to 3D game world space
       Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2d);
       
       // Move the x position of this Basket to the x position of the mouse
       Vector3 pos = this.transform.position;
       pos.x = mousePos3D.x;
       this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll) {
        // Check what hit the basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple")) {
            Destroy(collidedWith);
            scoreCounter.score += 100;  // Increase score
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score); // see if new score is a high score
        }
        else if (collidedWith.CompareTag("Branch")) {
            Destroy(collidedWith);
            // Get reference to ApplePicker component of Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // Call public AppleMissed() method
            apScript.LoseBasket();
        }
    }
}
