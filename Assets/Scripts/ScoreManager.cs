using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public TextMeshProUGUI scoreText;  
    private int score = 0;             

    void Awake()
    {
        Instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Счёт: " + score;
    }
}