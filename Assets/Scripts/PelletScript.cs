using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    private int points = 10;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PacStudent"))
        {
            // Add points to the score manager
            

            // Destroy the pellet GameObject
            Destroy(gameObject);
        }
    }
}
