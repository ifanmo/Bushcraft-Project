using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayAgainButton : MonoBehaviour
{
    [SerializeField] private Button buttonPlayAgainButton;
    [SerializeField] private GameObject gameOverScreen;

    public void PlayOnClick()
    {
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
