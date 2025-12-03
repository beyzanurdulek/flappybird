using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;

    public float spawnRate = 2f;       // Başlangıç boru çıkma süresi
    public float minSpawnRate = 0.8f;  // En hızlı olabileceği süre
    public float difficultySpeed = 0.05f; // Zamanla ne kadar hızlansın

    public float minY = -1f;
    public float maxY = 1f;

    float timer = 0f;

    void Update()
    {
        // Zaman geçtikçe spawnRate düşer → borular daha sıkleşir
        spawnRate = Mathf.Max(minSpawnRate, spawnRate - difficultySpeed * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            float y = Random.Range(minY, maxY);
            Vector3 pos = new Vector3(transform.position.x, y, 0f);

            Instantiate(pipePrefab, pos, Quaternion.identity);
            timer = 0f;
        }
    }
}

