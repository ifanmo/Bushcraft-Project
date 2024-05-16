using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;



    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score " + CraftingManager.Instance.GetScore();

    }
}
