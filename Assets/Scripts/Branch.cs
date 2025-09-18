using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour {
    // Height where branches are removed
    public static float BottomY = -20f;
    
    void Update()
    {
        // Remove apples that fall off the screen
        if (transform.position.y < BottomY) {
            Destroy(this.gameObject);
        }
    }
}
