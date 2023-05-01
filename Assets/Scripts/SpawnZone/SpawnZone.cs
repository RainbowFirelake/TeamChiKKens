
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public GameObject objectToSpawn; // префаб объекта, который будет создаваться
    public float spawnDelay = 1f; // задержка между созданием объектов
    public int maxSpawnCount = 10; // максимальное количество создаваемых объектов
    private int currentSpawnCount = 0; // текущее количество созданных объектов
    private float timeSinceLastSpawn = 0f; // время, прошедшее с последнего создания объекта
    public Collider spawnArea;
    void Update()
    {
        // проверяем, не превышено ли максимальное количество создаваемых объектов
        if (currentSpawnCount >= maxSpawnCount)
            return;

        // увеличиваем время, прошедшее с последнего создания объекта
        timeSinceLastSpawn += Time.deltaTime;

        // если прошла нужная задержка, создаем новый объект
        if (timeSinceLastSpawn >= spawnDelay)
        {
            Vector3 spawnPosition = spawnArea.bounds.center + Random.insideUnitSphere * spawnArea.bounds.extents.magnitude;
            spawnPosition.y += 10;
            GameObject newObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            currentSpawnCount++;
            timeSinceLastSpawn = 0f;
        }
    }
}
