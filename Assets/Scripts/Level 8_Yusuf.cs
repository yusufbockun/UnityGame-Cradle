using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level8 : MonoBehaviour
{
    // Start is called before the first frame update
    public VariablesSC change_global_value;
    public GameObject loadScene;
    private void Start()
    {
        loadScene.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!change_global_value.player.hasToy)
            {
                loadScene.SetActive(true);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
