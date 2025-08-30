using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float baseSpeed = .1f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private float moveSpeed = 0f;
    private float speedMultWhenStopped = 0f;
    private float speedMultWhenSlow = 0.5f;
    private float speedMultWhenNormal = 1f;

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
            float randomMult = UnityEngine.Random.value;

            switch (modifier)
            {
                case 1:
                    moveSpeed = baseSpeed * speedMultWhenStopped * randomMult;
                    break;

                case 2:
                    moveSpeed = baseSpeed * speedMultWhenSlow * randomMult;
                    break;

                case 3:
                    moveSpeed = baseSpeed * speedMultWhenNormal * randomMult;
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