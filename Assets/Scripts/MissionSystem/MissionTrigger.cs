using UnityEngine;

public class MissionTrigger : MonoBehaviour
{
    [SerializeField]
    BaseMission _mission;

    private bool _isActivated = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !_isActivated)
        {
            _mission.StartMission();
        }
    }
}