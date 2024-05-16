using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    public TextMeshProUGUI gameOverText;


    public void Start()
    {
        gameOverScreen.SetActive(false);
        GameTimerUI.Instance.OnGameOver += Instance_OnGameOver;
        
    }

    private void Instance_OnGameOver(object sender, System.EventArgs e)
    {
        gameOverScreen.SetActive(true);
        gameOverText.text = CraftingManager.Instance.GetScore() + " points";
    }
}
