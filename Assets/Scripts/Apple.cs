using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {
    // Height where apples are removed
    public static float BottomY = -20f;
    
    void Update()
    {
        // Remove apples that fall off the screen
        if (transform.position.y < BottomY) {
            Destroy(this.gameObject);
            
            // Get reference to ApplePicker component of Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // Call public LoseBasket() method
            apScript.LoseBasket();
        }
        
    }
}
