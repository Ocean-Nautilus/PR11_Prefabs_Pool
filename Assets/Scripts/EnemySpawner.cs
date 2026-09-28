using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Header("Ссылки")]
    public ObjectPool objectPool;
    public TextMeshProUGUI statusText;
    public Button spawnButton;
    public Button spawnManyButton;

    [Header("Настройки")]
    public float spawnInterval = 2f;
    private float timer;

    public string[] enemyTags = { "EnemyRed", "EnemyNig", "EnemyOrange" };

    void Start()
    {
        spawnButton.onClick.AddListener(SpawnEnemy);
        spawnManyButton.onClick.AddListener(SpawnManyEnemies);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0;
            SpawnEnemy();
        }
    }

    string GetRandomEnemyTag()
    {
        int index = Random.Range(0, enemyTags.Length);
        return enemyTags[index];
    }

    public void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-8f, 8f), 6f, 0);

        objectPool.SpawnFromPool(GetRandomEnemyTag(), spawnPos, Quaternion.identity);

        statusText.text = "Враг заспавнен!";
    }

    public void SpawnManyEnemies()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-8f, 8f), 6f + i, 0);
            objectPool.SpawnFromPool(GetRandomEnemyTag(), spawnPos, Quaternion.identity);
        }
        statusText.text = "Заспавнено 5 врагов!";
    }
}