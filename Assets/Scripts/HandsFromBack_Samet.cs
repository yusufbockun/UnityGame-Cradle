using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsFromBack : MonoBehaviour
{

    [SerializeField] private VariablesSC variables;
    void Update()
    {
        transform.position += Vector3.right * variables.hands.HandsSpeed * Time.deltaTime;
    }
}
