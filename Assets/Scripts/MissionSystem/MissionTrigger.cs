using UnityEngine;

public class MissionTrigger : MonoBehaviour
{
    [SerializeField]
    BaseMission _mission;
    [SerializeField]
    private DialogueArea _dialogueArea;
    [SerializeField]
    private bool _enableOnStart;

    private bool _isActivated = false;

    void Start()
    {
        if (_enableOnStart) 
        {
            _mission.StartMission();
            _dialogueArea.ActivateDialogue();
            _isActivated = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !_isActivated)
        {
            _mission.StartMission();
            _dialogueArea.ActivateDialogue();
        }
    }
}