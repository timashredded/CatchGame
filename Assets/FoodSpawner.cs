using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    private float spawnTimer;
    private float difficultyTimer;

    public float horizontalPadding = 0.8f;

    private float lastSpawnTime;
    public float minSpawnInterval = 0.8f;
    public float minPossibleInterval = 0.05f;
    public float intervalDecreaseStep = 0.05f;


    public GameObject foodPrefab;
    public GameObject badItemPrefab;

    private float lastSpawnX;
    public float minXDistance = 1.2f;
    private bool lastWasBad = false;

    public float spawnRate = 1f;

    public float minSpawnRate = 0.3f;
    public float difficultyIncreaseTime = 10f;
    public float spawnRateStep = 0.1f;

    public float spawnY = 6f;

    void Start()
    {
        
    }

    void SpawnItem()
    {
        if (Time.time - lastSpawnTime < minSpawnInterval)
        {
            return;
        }

        float randomX;
        int safety = 0;

        do
        {
            Vector3 left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
            Vector3 right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));

            randomX = Random.Range(
                left.x + horizontalPadding,
                right.x - horizontalPadding
            );

            safety++;
        }
        while (Mathf.Abs(randomX - lastSpawnX) < minXDistance && safety < 10);

        lastSpawnX = randomX;

        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0);

        bool spawnBad = Random.Range(0, 4) == 0;

        if (spawnBad && lastWasBad)
        {
            spawnBad = false;
        }

        if (spawnBad)
        {
            Instantiate(badItemPrefab, spawnPosition, Quaternion.identity);
            lastWasBad = true;
        }
        else
        {
            Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
            lastWasBad = false;
        }

        lastSpawnTime = Time.time;

    }

    void IncreaseDifficulty()
    {
        if (spawnRate > minSpawnRate)
        {
            spawnRate -= spawnRateStep;

        }

        if (minSpawnInterval > minPossibleInterval)
        {
            minSpawnInterval -= intervalDecreaseStep;
        }

        GameManager.Instance.targetFallMultiplier += 0.1f;

    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        difficultyTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
            SpawnItem();
            spawnTimer = 0f;
        }

        if (difficultyTimer >= difficultyIncreaseTime)
        {
            IncreaseDifficulty();
            difficultyTimer = 0f;
        }
    }


}
