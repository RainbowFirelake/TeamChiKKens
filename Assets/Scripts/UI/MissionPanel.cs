using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionPanel : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _missionInfoText;
    [SerializeField]
    private TMP_Text _missionCompletionText;

    void OnEnable()
    {
        BaseMission.OnMissionStart += SetMissionInfo;
        BaseMission.OnMissionCompletionUpdate += SetMissionCompletionInfo;
        BaseMission.OnMissionEnd += SetEndMission;
    }

    void OnDisable()
    {
        BaseMission.OnMissionStart -= SetMissionInfo;
        BaseMission.OnMissionCompletionUpdate -= SetMissionCompletionInfo;
        BaseMission.OnMissionEnd -= SetEndMission;
    }

    private void SetMissionInfo(string missionInfo)
    {
        _missionInfoText.text = missionInfo;
    }

    private void SetMissionCompletionInfo(string missionCompletionInfo)
    {
        _missionCompletionText.text = missionCompletionInfo;
    }

    private void SetEndMission()
    {
        _missionInfoText.text = "";
        _missionCompletionText.text = "";
    }
}
