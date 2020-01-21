using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    GameStatus gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        /**
         * here is a weird bug
         * it is very inefficient to call FindObjectOfType every frame
         * however, if this line of code is put in Start()
         * the gameStatus would not be the one we are looking for
         * it should be related to my impletation of Singleton
         * but for now, I cannot find a good solution...
         **/
        gameStatus = FindObjectOfType<GameStatus>();
        scoreText.text = gameStatus.GetScore().ToString();
    }
}
