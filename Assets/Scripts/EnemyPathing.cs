using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] WaveConfig waveConfig;

    List<Transform> wavepoints = new List<Transform>();
    int targetIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetWavePoints();

        transform.position = wavepoints[targetIndex].position;
        targetIndex++;
    }

    private void GetWavePoints()
    {
        var path = waveConfig.getPathPrefab();
        foreach (Transform wavepoint in path.transform)
        {
            wavepoints.Add(wavepoint); // must initiate before Add
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (targetIndex < wavepoints.Count)
        {
            var currentPos = transform.position;
            var targetPos = wavepoints[targetIndex].position;
            var moveSpeed = waveConfig.getMoveSpeed();

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
