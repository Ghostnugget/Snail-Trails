using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = .1f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
        moveInput.x = 1;
        moveInput.y = 0;
    }

    void Update()
    {
        if (UnityEngine.Random.value > 0.99)
        {
            int modifier = UnityEngine.Random.Range(1, 4);
            switch (modifier)
            {
                case 1:
                    moveSpeed = 0;
                    break;

                case 2:
                    moveSpeed = UnityEngine.Random.value * 0.5f;
                    break;

                case 3:
                    moveSpeed = UnityEngine.Random.value;
                    break;

                default: 
                    Debug.Log("Check update function.");
                    break;
            }
        }
    }

    void FixedUpdate()
    {
        // Apply movement to the Rigidbody2D in FixedUpdate for physics consistency
        rb.velocity = moveInput * moveSpeed;
    }
}

// Spray Bottle, randomly change directions, Obstacles, Nametags, Betting, Start/Finish Line, Different Maps, Snail Personalities, Outline for Snails - Shader