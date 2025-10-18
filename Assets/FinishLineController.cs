using System;
using UnityEngine;

public class FinishLineController : MonoBehaviour
{
    // A boolean to make sure we only declare a winner once.
    private bool raceFinished = false;

    // This function is automatically called by Unity when another collider enters this trigger.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the race is already over and if the object that entered has the "Snail" tag.
        if (!raceFinished && other.CompareTag("Snail"))
        {
            // Set the flag to true so this code doesn't run again.
            raceFinished = true;

            // Get the name of the winning snail and print it to the console.
            string winnerName = other.gameObject.name;
            Debug.Log("The winner is: " + winnerName + "!");
            Console.WriteLine("The winner is: " + winnerName + "!");
            // You can add more code here later to show a victory screen or stop the other snails.
        }
    }
}