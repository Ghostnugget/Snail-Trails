using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Rendering;
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

        moveSpeed = baseSpeed * speedMultWhenNormal;
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


// 0.5 Tier Character Selection?, Nametag Background color
// Tier 1 (4 directional movement): randomly change directions - make it more likely they go right
// Tier 1.5 (almost ready): 
//: Obstacles (dynamic vs static?, do obstacles move?, randomly generated?)


// Tier 3 (major features): Betting, Spray Bottle, (Character customization/selection, User enters their names and chooses a color, Snail Personalities?), (Different Maps - Map selection screen)


//Done:  Nametags - some way to distinguish them? , Outline for Snails - Shader, Start/Finish Line