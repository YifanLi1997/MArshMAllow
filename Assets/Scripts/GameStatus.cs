using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    // config params
    [SerializeField] int pointsPerHit = 20;
    [SerializeField] TextMeshProUGUI scoreText;

    // state vars
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    { 
        scoreText.text = "Score: " + currentScore.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddExplosionPoint(int explosionPoint)
    {
        currentScore += explosionPoint;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void AddHitPoint()
    {
        currentScore += pointsPerHit;
        scoreText.text = "Score: " + currentScore.ToString();
    }
}
