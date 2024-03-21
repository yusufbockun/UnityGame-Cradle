using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class triggerSound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource current;
    public int destroyTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            current.Play();
            Destroy(gameObject, destroyTime);
        }
    }
}
