using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    List<GameObject> gameObjects = new List<GameObject>();

    GameObject Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void OnEnable()
    {
        Health.OnChangeMan += OnDeadPlayer;
    }

    private void OnDeadPlayer()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Ally").ToList();
        if (gameObjects.Count == 0)
        {
            Destroy(Player);
            return;
            //Todo Lose
        }
        int randomIndex = Random.Range(0, gameObjects.Count - 1);
        Player.transform.position = gameObjects[randomIndex].transform.position;
        Destroy(gameObjects[randomIndex]);
        Player.GetComponent<Health>().SetHealth(100f);
    }
}
