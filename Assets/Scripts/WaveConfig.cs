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

    public GameObject getEnemyPrefab() { return enemyPrefab; }

    public GameObject getPathPrefab() { return pathPrefab; }

    public float getSpawnGap() { return spawnGap; }

    public int getNumOfEnemies() { return numOfEnemies; }

    public float getMoveSpeed() { return moveSpeed; }




}
