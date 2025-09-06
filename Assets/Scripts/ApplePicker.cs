using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour {
    [Header("Inscribed")] 
    public GameObject basketPrefab;

    public int numBaskets = 3;
    
    // Height for the first basket 
    public float basketBottomY = -14f;
    
    // Vertical space between baskets
    public float basketSpacingY = 2f;
    
    void Start()
    {
        // Create a Basket numBaskets times
        for (int i = 0; i < numBaskets; i++) {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i); // Start at bottom and space based on spacing var
            tBasketGo.transform.position = pos;
        }
    }
}
