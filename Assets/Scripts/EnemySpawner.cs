using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingIndex = 0;
    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    private IEnumerator Start()
    {
        //while (looping)
        //{
        //    yield return StartCoroutine(SpawnAllEnemies());
        //}

        // with this implementation, the corotine will be executed
        // for at least once, even if the looping is false
        do
        {
            yield return StartCoroutine(SpawnAllEnemies());
        } while (looping);
    }

    private IEnumerator SpawnAllEnemies()
    {
        for (int i = startingIndex; i < waveConfigs.Count; i++)
        {
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnEnemiesInOneWave(currentWave));
        }
    }

    // A coroutine is a function that can suspend its execution (yield)
    // until the given YieldInstruction finishes.
    private IEnumerator SpawnEnemiesInOneWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumOfEnemies(); i++)
        {
            var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWavepoints()[0].position,
                Quaternion.identity
                );
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetSpawnGap());
        }
    }
}
