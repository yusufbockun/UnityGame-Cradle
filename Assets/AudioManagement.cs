using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource currentMove;
    public AudioClip rockGround;


    public  void walkRockGround()
    {
        currentMove.clip = rockGround;
        currentMove.Play();
    }
    public void walkGrassGround()
    {
        currentMove.clip = rockGround;
        currentMove.Play();
    }
    public void walkDirtGround()
    {
        currentMove.clip = rockGround;
        currentMove.Play();
    }

}
