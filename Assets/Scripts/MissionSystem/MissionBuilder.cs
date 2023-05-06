using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionBuilder : MonoBehaviour
{
    [SerializeField]
    private List<BaseMission> _missions;

    void Start()
    {
        foreach (var mission in _missions)
        {
            var m = Instantiate(mission);
        }

        for (int i = 0; i < _missions.Count - 1; i++)
        {
            _missions[i]._nextMission = _missions[i + 1];
        }

        _missions[0].StartMission();
    }
}
