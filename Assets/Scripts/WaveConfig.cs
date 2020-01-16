using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float spawnGap;
    [SerializeField] int numOfEnemies;
    [SerializeField] float moveSpeed;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public List<Transform> GetWavepoints()
        // much more convenient than simply return the path prefab
    {
        var wavepoints = new List<Transform>();
        foreach (Transform wavepoint in pathPrefab.transform)
        {
            wavepoints.Add(wavepoint); // must initiate before Add
        }
        return wavepoints;
    } 

    public float GetSpawnGap() { return spawnGap; }

    public int GetNumOfEnemies() { return numOfEnemies; }

    public float GetMoveSpeed() { return moveSpeed; }




}
