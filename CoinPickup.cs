using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{



    [SerializeField] AudioClip coinSound;
    [SerializeField] int pointsForFragmentPickup = 1;

    bool wasCollected = false;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;

            FindObjectOfType<GameSession>().AddToScore(pointsForFragmentPickup);

            AudioSource.PlayClipAtPoint(coinSound, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    
}
