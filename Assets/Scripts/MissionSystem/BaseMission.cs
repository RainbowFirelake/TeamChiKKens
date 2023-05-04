using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMission : MonoBehaviour
{
    public static event Action<String> OnMissionStart;
    public static event Action<String> OnMissionCompletionUpdate;
    public static event Action OnMissionEnd;

    public abstract void StartMission();
    public abstract void EndMission();

    protected void OnMissionStartInvoke(string missionInfo)
    {
        OnMissionStart?.Invoke(missionInfo);
    }

    protected void OnMissionCompetionUpdateInvoke(string missionCompletionInfo)
    {
        OnMissionCompletionUpdate?.Invoke(missionCompletionInfo);
    }

    protected void OnMissionEndInvoke()
    {
        OnMissionEnd?.Invoke();
    }
}
