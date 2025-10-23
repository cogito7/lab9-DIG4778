using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public int score = 0;
    private void Awake()
    {
        if (instance != null)
        {
            this.score = instance.score;
            UpdateScoreText();
        }
        instance = this;
    }
    private void OnEnable()
    {
        Target.OnTargetHit += AddScore; // subscribe
    }
    private void OnDisable()
    {
        Target.OnTargetHit -= AddScore; // unsubscribe to avoid leaks
    }

    private void Start()
    {
        UpdateScoreText();
    }


    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText() 
    {
        scoreText.text = "Score: " + score;
    }
}
