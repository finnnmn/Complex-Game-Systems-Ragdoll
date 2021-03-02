using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] Text scoreText;


    private void Start()
    {
        winPanel.SetActive(false);
    }
    public void WinGame(int _score)
    {
        winPanel.SetActive(true);
        scoreText.text = "SCORE: " + _score;
    }

}
