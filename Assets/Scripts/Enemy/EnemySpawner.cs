using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

public class EnemySpawner : MonoBehaviour
{
    [SerializedDictionary("Enemy", "Chance")] public SerializedDictionary<Enemy, int> enemiesChance;
    [SerializeField] private List<Enemy> enemiesBin;
    [SerializeField] private Transform player;

    public float x, y;
    private Vector2 minBounds;
    private Vector2 maxBounds;
    public float checkRadius = 5f;
    public LayerMask targetLayer;
    public Transform ground;
    public float distanceGround;

    public void Initialize()
    {
        InvokeRepeating(nameof(SpawnEnemy), .1f, .01f);
    }

    private void SpawnEnemy()
    {
        if (player != null)
        {
            Vector3 spawnPosition = GetPosition();

            if (IsPostionValid(spawnPosition))
            {
                Enemy enemy = Instantiate(GetRandomEnemy(), spawnPosition, Quaternion.identity);
                enemy.Rotation();
                enemiesBin.Add(enemy);
            }
        }
    }

    private Enemy GetRandomEnemy()
    {
        int chance = Random.Range(0, 100);

        foreach (var enemyType in enemiesChance)
        {
            if (chance < enemyType.Value)
            {
                return enemyType.Key;
            }
        }

        Debug.LogError("Враг не найден");
        return null;
    }

    private Vector3 GetPosition()
    {
        MakePerimetr();

        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);

        Vector3 spawnPosition = new Vector3(randomX, randomY);
        return spawnPosition;
    }

    private void MakePerimetr()
    {
        Vector3 playerPosition = player.position;

        minBounds = new Vector2(playerPosition.x - x, playerPosition.y - y);
        maxBounds = new Vector2(playerPosition.x + x, playerPosition.y + y);
    }

    private bool IsPostionValid(Vector3 positionForCheck)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(positionForCheck, checkRadius, targetLayer);

        if (hitColliders.Length <= 0 && Mathf.Abs(ground.position.y + distanceGround) > Mathf.Abs(positionForCheck.y))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CleanTheMap()
    {
        for (int i = 0; i < enemiesBin.Count; i++)
        {
            if (enemiesBin[i] != null)
            {
                if (Vector2.Distance(enemiesBin[i].transform.position, player.position) > 300)
                {
                    Destroy(enemiesBin[i].gameObject);
                    enemiesBin.Remove(enemiesBin[i]);
                }
            }
            else
            {
                enemiesBin.Remove(enemiesBin[i]);
            }
        }
    }
}