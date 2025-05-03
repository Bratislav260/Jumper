using UnityEngine;
using System.Collections.Generic;

public class PlatformSetManager : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject lava;
    [SerializeField] private Transform player;
    public List<Transform> platformBin = new List<Transform>();
    private SpriteRenderer spriteRendererPlatform;

    public float platformSize = 50;
    public float xStart, xEnd;
    private float x1, x2;
    public float y;
    public float bufferDistance = 150f;
    public float cleanDistance = 200f;

    public void Initialize()
    {
        spriteRendererPlatform = platform.GetComponent<SpriteRenderer>();
        platformSize = GetPlatformWidth(spriteRendererPlatform);

        x1 = player.position.x + xStart;
        x2 = player.position.x + xEnd;

        SetStartPlatform();
        CreatPlatforms(x1, x2);
    }

    private void CreatPlatforms(float x1, float x2, bool isLeft = false)
    {
        float currentX = Mathf.Min(x1, x2);
        float targetX = Mathf.Max(x1, x2);
        List<Transform> tempList = new List<Transform>();

        while (currentX < targetX)
        {
            GameObject plat1 = Instantiate(GetRandonPlat(), new Vector2(currentX, y), Quaternion.Euler(0, 0, 180)); // вверхная платформа
            GameObject plat2 = Instantiate(GetRandonPlat(), new Vector2(currentX, -y), Quaternion.identity); // нижная платформа 

            if (isLeft)
            {
                tempList.Add(plat1.transform);
                tempList.Add(plat2.transform);
            }
            else
            {
                platformBin.Add(plat1.transform);
                platformBin.Add(plat2.transform);
            }

            currentX += platformSize;
        }

        if (isLeft)
        {
            AddList(tempList);
        }
    }

    private void AddList(List<Transform> platList)
    {
        for (int i = platList.Count - 1; i >= 0; i--)
        {
            platformBin.Insert(0, platList[i]);
        }
    }

    private GameObject GetRandonPlat()
    {
        int chance = Random.Range(0, 100);

        if (chance < 50)
        {
            return platform;
        }
        else if (chance < 100)
        {
            return lava;
        }
        else
        {
            Debug.LogError("Нет платформы");
            return null;
        }
    }

    public void SetNewPlatform()
    {
        float ballX = player.position.x;

        if (ballX < platformBin[0].position.x + bufferDistance)
        {
            x1 = platformBin[0].position.x;
            float newX1 = platformBin[0].position.x + xStart;

            // Debug.Log("LEFT");
            CreatPlatforms(newX1, x1, true);
            CleanUpRight(ballX);

        }
        else if (ballX > platformBin[platformBin.Count - 1].position.x - bufferDistance)
        {
            x2 = platformBin[platformBin.Count - 1].position.x + platformSize;
            float newX2 = ballX + xEnd;
            // Debug.Log("RIGHT");

            CreatPlatforms(x2, newX2);
            CleanUpLeft(ballX);
        }
    }

    private void CleanUpLeft(float ballPos)
    {
        for (int i = platformBin.Count - 1; i >= 0; i--)
        {
            if (platformBin[i].position.x < ballPos - cleanDistance)
            {
                Destroy(platformBin[i].gameObject);
                platformBin.Remove(platformBin[i]);
            }
        }
    }
    private void CleanUpRight(float ballPos)
    {
        for (int i = platformBin.Count - 1; i >= 0; i--)
        {
            if (platformBin[i].position.x > ballPos + cleanDistance)
            {
                Destroy(platformBin[i].gameObject);
                platformBin.Remove(platformBin[i]);
            }
        }
    }

    private float GetPlatformWidth(SpriteRenderer spriteRenderer)
    {
        if (spriteRenderer != null && spriteRenderer.bounds.size.x > 0)
        {
            return spriteRenderer.bounds.size.x;
        }
        return 50f;
    }

    private void SetStartPlatform()
    {
        // Debug.Log("Стартовая Платформа");
        Vector2 playerPosition = new Vector2(player.position.x, player.position.y - 3);
        GameObject startPlatform = Instantiate(platform, playerPosition, Quaternion.identity);


        Destroy(startPlatform, 3f);
    }
}
