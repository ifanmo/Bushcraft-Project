using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons: MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    // Start is called before the first frame update
    public void PlayOnClick()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitOnClick()
    {
        Application.Quit();
    }
}
