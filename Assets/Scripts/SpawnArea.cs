using UnityEngine;
using System.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;
using System.Threading;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Pool))]

public class SpawnArea : MonoBehaviour
{
    Pool pool;
    private CancellationTokenSource cancellationToken;
    [SerializeField] Vector2 spawnSize;

    void Start()
    {
        cancellationToken = new CancellationTokenSource();
        pool = GetComponent<Pool>();
        Spawn(cancellationToken);
    }

    private void OnDisable()
    {
        cancellationToken.Cancel();
        cancellationToken.Dispose();
    }

    async void Spawn(CancellationTokenSource cancellationToken)
    {
        while (SceneManager.GetActiveScene().name == "GameScene")
        {
            if (cancellationToken.Token.IsCancellationRequested)
            {
                break;
            }
            int randVector = Random.Range(0, 4);
            pool.GetFreeElement(GetRandomSpawnPosition(randVector), Quaternion.identity);
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(5.0f - WaveManager.currentLvl / 2), cancellationToken.Token);
            }
            catch
            {

            }         
        }
    }

    Vector2 GetRandomSpawnPosition(int rand)
    {
        var result = Vector2.zero;
        if (rand < 2)
        {
            result = new Vector2(rand % 1 == 0 ? -spawnSize.x : spawnSize.x, Random.Range(-spawnSize.y * 0.5f, spawnSize.y * 0.5f));
           
        }
        else
        {
            result = new Vector2(Random.Range(-spawnSize.x * 0.5f, spawnSize.x * 0.5f), rand % 1 == 0 ? -spawnSize.y : spawnSize.y);
        }
        return result;
    }
}
