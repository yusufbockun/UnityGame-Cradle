using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour

{
    [SerializeField] private VariablesSC variables;
    private Rigidbody2D rig2d;
    private Animator anim;
    private PlayerMovementSC playerMove;
    public GameObject gameOverScreen; 
    private void Start()
    {
        anim = GetComponent<Animator>();
        rig2d = GetComponent<Rigidbody2D>();
        playerMove = GetComponent<PlayerMovementSC>();
        gameOverScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            variables.player.isAlive = false;
            anim.SetBool("death",true);
            gameObject.transform.SetParent(collision.gameObject.transform);
            rig2d.bodyType = RigidbodyType2D.Static;
            playerMove.enabled = false;
            gameOverScreen.SetActive(true);
            StartCoroutine(restartGame());
        }

    }
    private IEnumerator restartGame()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
