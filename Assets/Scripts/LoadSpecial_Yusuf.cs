using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecial : MonoBehaviour
{
    // Start is called before the first frame update
    public VariablesSC change_global_variable;
    public Rigidbody2D player;
    public Animator anim;
    public GameObject loadscene;
    private void Start()
    {
            loadscene.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

            if (collision.gameObject.CompareTag("Player"))
            {
                anim.SetBool("death",true);
                player.bodyType = RigidbodyType2D.Static;
            loadscene.SetActive(true);
            StartCoroutine(load());


            }
        
    }

    private IEnumerator load()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
