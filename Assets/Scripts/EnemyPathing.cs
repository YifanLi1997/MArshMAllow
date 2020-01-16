using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> wavepoints;
    int targetIndex = 1;

    // Start is called before the first frame update
    void Start()
    {
        wavepoints = waveConfig.GetWavepoints();
        transform.position = wavepoints[0].position; // initialize
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    void Move()
    {
        if (targetIndex < wavepoints.Count)
        {
            var currentPos = transform.position;
            var targetPos = wavepoints[targetIndex].position;
            var moveSpeed = waveConfig.GetMoveSpeed();

            transform.position = Vector2.MoveTowards(
                currentPos,
                targetPos,
                moveSpeed * Time.deltaTime);
            if (transform.position == targetPos)
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
