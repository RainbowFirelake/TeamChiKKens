using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMission : MonoBehaviour
{
    public static event Action<String> OnMissionStart;
    public static event Action<String> OnMissionCompletionUpdate;
    public static event Action OnMissionEnd;

    [SerializeField]
    private List<GameObject> _objectToActivateWhenStarted;
    [SerializeField]
    private List<GameObject> _objectToActivateWhenEnded;
    [SerializeField]
    protected string _missionInfo;
    [SerializeField]
    private bool _isPlayingMusicOnStart;
    [SerializeField]
    private MusicType _musicType;

    public abstract void StartMission();
    public abstract void EndMission();

    void Start()
    {
        if (_isPlayingMusicOnStart)
        {
            MusicPlayer.instance.PlayMusic(_musicType);
        }
    }

    protected void EnableObjectsOnStartMission()
    {
        if (_objectToActivateWhenStarted.Count == 0) return;

        foreach (var obj in _objectToActivateWhenStarted)
        {
            obj.SetActive(true);
        }
    }

    protected void EnableObjectsWhenEndMission()
    {
        if (_objectToActivateWhenEnded.Count == 0) return;

        foreach (var obj in _objectToActivateWhenEnded)
        {
            obj.SetActive(true);
        }
    }

    protected void OnMissionStartInvoke(string missionInfo)
    {
        OnMissionStart?.Invoke(missionInfo);
    }

    protected void OnMissionCompletionUpdateInvoke(string missionCompletionInfo)
    {
        OnMissionCompletionUpdate?.Invoke(missionCompletionInfo);
    }

    protected void OnMissionEndInvoke()
    {
        OnMissionEnd?.Invoke();
    }
}
