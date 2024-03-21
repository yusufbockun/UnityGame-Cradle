using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton_YusufB : MonoBehaviour
{
    // Start is called before the first frame update
    public VariablesSC change_global_value;
    private bool enterButtonZone = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && enterButtonZone)
        {
            change_global_value.platform.active = !change_global_value.platform.active;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
       
            if (collision.gameObject.CompareTag("Player"))
            {
                enterButtonZone = true;
            }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enterButtonZone = false;
        }
    }

}
