using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_YusufB : MonoBehaviour
{
    // Start is called before the first frame update
    public VariablesSC global_variable;
    public int handSpeed;
    void Start()
    {
        global_variable.player.hasToy = false;
        global_variable.player.isAlive = true;
        global_variable.platform.active = false;
        global_variable.hands.HandsSpeed= handSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
