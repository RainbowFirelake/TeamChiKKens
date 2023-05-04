using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionPanel : MonoBehaviour
{
    public static MissionPanel instance = null;

    [SerializeField]
    private TMP_Text _missionInfoText;
    [SerializeField]
    private TMP_Text _missionCompletionText;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void OnEnable()
    {
        BaseMission.OnMissionStart += SetMissionInfo;
        BaseMission.OnMissionCompletionUpdate += SetMissionCompletionInfo;
        BaseMission.OnMissionEnd += SetEndMission;
    }

    public void SetMissionInfo(string missionInfo)
    {
        _missionInfoText.text = missionInfo;
    }

    public void SetMissionCompletionInfo(string missionCompletionInfo)
    {
        _missionCompletionText.text = missionCompletionInfo;
    }

    public void SetEndMission()
    {
        _missionInfoText.text = "";
        _missionCompletionText.text = "";
    }
}
