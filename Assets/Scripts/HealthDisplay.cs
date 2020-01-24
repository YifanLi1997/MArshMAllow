using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    // config
    [SerializeField] GameObject[] clouds = new GameObject[10];

    Player player;
    bool[] displayOrNot = new bool[10]
        {false, false, false, false, false, false, false, false, false, false};

    // state
    [SerializeField] int health;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetHealth();
        for (int i = 0; i < 10; i++)
        {
            float numOfClouds = health / 100;
            if (i < numOfClouds)
            {
                displayOrNot[i] = true;
            }
            else
            {
                displayOrNot[i] = false;
            }
            clouds[i].SetActive(displayOrNot[i]);
        }
    }
}
