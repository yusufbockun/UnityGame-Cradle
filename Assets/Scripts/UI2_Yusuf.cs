using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI2 : MonoBehaviour
{
    // Start is called before the first frame update

    public void load_scene()
    {
        Button button = GetComponent<Button>();
        Text textComponent = button.GetComponentInChildren<Text>();
        string buttonText = textComponent.text;
        SceneManager.LoadScene(int.Parse(buttonText));
    }
    public void go_menu()
    {
        SceneManager.LoadScene(0);
    }
    public void gameMute(bool muted)
    {
        AudioListener.volume = 0;
    }

    public void gameUnmute(bool muted)
    {
        AudioListener.volume = 1;
    }
}
