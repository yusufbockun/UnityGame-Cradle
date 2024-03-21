using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject loadScene, howToPlayScene,mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        loadScene.SetActive(false);
        howToPlayScene.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void start_game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void exit_game()
    {
        Application.Quit();
    }
    public void main_menu()
    {
        loadScene.SetActive(false);
        howToPlayScene.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void load_game()
    {
        loadScene.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void how_to_play()
    {
        howToPlayScene.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void soundoff()
    {
        AudioListener.volume = 0;
    }

}
