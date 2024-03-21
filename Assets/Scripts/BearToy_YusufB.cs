using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearToy_YusufB : MonoBehaviour
{
    // Start is called before the first frame update
    public VariablesSC change_global_variable;
    public AudioSource hasToyy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasToyy.Play();
            change_global_variable.player.hasToy=true;
           Destroy(gameObject,0.1f);
        }
    }
}
