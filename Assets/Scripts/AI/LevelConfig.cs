using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Waves",menuName = "Enemy", order = 0)]
public class LevelConfig : ScriptableObject
{
    public List<GameObject> gameObjects = new List<GameObject>();

    public int Count;

    public int MaxCountinGroupe;

    public float secondBetweenSpawn;
}
