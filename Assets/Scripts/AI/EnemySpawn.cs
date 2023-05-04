using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private LevelConfig _level;
    int _spawnCount = 0;    
    GameObject[] transforms;
    private void Start()
    {
        transforms = GameObject.FindGameObjectsWithTag("SpawnZoneEnemy");
        _spawnCount = _level.Count;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (_spawnCount > 0)
        {
            int countGrope = Random.Range(1, _level.MaxCountinGroupe);

            for (int i = 0; i < countGrope; i++)
            {
                Instantiate(_level.gameObjects[Random.Range(0, _level.gameObjects.Count - 1)], transforms[Random.Range(0, transforms.Length)].transform.position, Quaternion.identity);
            }
            _spawnCount -= countGrope;
            yield return new WaitForSeconds(_level.secondBetweenSpawn);
        }
    }
}
