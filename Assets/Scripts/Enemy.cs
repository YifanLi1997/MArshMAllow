using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 500;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] List<GameObject> wavepoints;

    int targetIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = wavepoints[targetIndex].transform.position;
        targetIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if(targetIndex < wavepoints.Count)
        {
            var currentPos = transform.position;
            var targetPos = wavepoints[targetIndex].transform.position;
            transform.position = Vector2.MoveTowards(
                currentPos,
                targetPos,
                moveSpeed * Time.deltaTime);
            if(transform.position == targetPos)
            {
                targetIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
