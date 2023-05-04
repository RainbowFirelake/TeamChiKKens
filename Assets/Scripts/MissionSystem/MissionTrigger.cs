using UnityEngine;

public class MissionTrigger : MonoBehaviour
{
    [SerializeField]
    BaseMission _mission;
    [SerializeField]
    private bool _enableOnStart;

    private bool _isActivated = false;

    void Start()
    {
        if (_enableOnStart) _mission.StartMission();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !_isActivated)
        {
            _mission.StartMission();
        }
    }
}