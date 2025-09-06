using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    
    // Prefab for instantiating apples
    public GameObject applePrefab;
    
    // Speed that AppleTree moves
    public float speed = 1f;
    
    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;
    
    // Chance that the AppleTree will change direction
    public float changeDirectionChance = 0.1f;
    
    // Time between Apple drops in seconds
    public float appleDropDelay = 1f;
    
    void Start()
    {
        // Start dropping apples        
    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge) { // Hit left bound
            speed = Mathf.Abs(speed); // Move right
        }
        else if (pos.x > leftAndRightEdge) { // Hit right bound
            speed = -Mathf.Abs(speed); // Move left
        }
        
    }

    void FixedUpdate() {
        // This must be in fixed so that the chance is consistent regardless of fps
        if (UnityEngine.Random.value < changeDirectionChance) { // Randomly Change direction based on defined chance
            speed *= -1; // Change direction
        }
    }
    
}
