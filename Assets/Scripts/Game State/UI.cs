using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text Health, Score;
    [SerializeField]
    private GameObject Button;

    private int CurrentScore;

    public void UpdateHealth(int value)
    {
        Health.text = "Health: " + value;
    }

    public void IncrementScore()
    {
        CurrentScore++;
        Score.text = "Score: " + CurrentScore;
    }

    public void ResetScore()
    {
        CurrentScore = 0;
    }

    public void HideButton()
    {
        Button.SetActive(false);
    }

    public void ShowButton()
    {
        Button.SetActive(true);
    }
}
