using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
    [Header("Inscribed")] 
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f; // Height for the first basket  
    public float basketSpacingY = 2f; // Vertical space between baskets 
    public List<GameObject> basketList;
    public GameObject gameOverButtons; // Object that holds buttons that appear on game over
    
    
    void Start()
    {
        gameOverButtons.SetActive(false); // hide game over ui
        
        // Create a Basket numBaskets times
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++) {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i); // Start at bottom and space based on spacing var
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);
        }
        
        StatusText.Status = 1; // Set round to 1
    }

    public void AppleMissed() {
        if (basketList.Count == 0) { // Skip if already at 0
            return;
        }
        
        // Destroy all apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in appleArray) {
            Destroy(apple);
        }
        
        // Destroy all branches
        GameObject[] branchArray = GameObject.FindGameObjectsWithTag("Branch");
        foreach (GameObject branch in branchArray) {
            Destroy(branch);
        }
        
        // Destroy a basket
        int basketIndex = basketList.Count - 1; // Get index of last basket
        GameObject basketGo = basketList[basketIndex]; // Get reference to that Basket GameObject
        // Remove Basket from list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGo);
        StatusText.Status = numBaskets - basketList.Count + 1; // Update status to current round
        
        // If no more baskets set status to game over
        // This should only run once since we return the start of this function if 0
        if (basketList.Count == 0) {
            StatusText.Status = -1;
            gameOverButtons.SetActive(true); // Set retry and quit buttons to active
        }
    }
}
