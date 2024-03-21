using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsSound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource current;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            current.Play();
            Debug.Log("çalýþýyom");

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            current.Stop();

        }

    }
}
