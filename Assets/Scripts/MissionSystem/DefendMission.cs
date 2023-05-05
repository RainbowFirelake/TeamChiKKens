using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefendMission : BaseMission
{
    [SerializeField] private float _timeToDefend = 180f;

    private float _timeLeft = 0f;

    void OnEnable()
    {
        PlayerHeadQuarters.OnDestroyPlayerHQ += MissionFailed;
    }

    public override void EndMission()
    {
        EnableObjectsWhenEndMission();
        OnMissionEndInvoke();
        this.gameObject.SetActive(false);
    }

    public override void StartMission()
    {
        OnMissionStartInvoke(_missionInfo);
        EnableObjectsOnStartMission();
        _timeLeft = _timeToDefend;
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            OnMissionCompletionUpdateInvoke(GetTimeString());
            yield return null;
        }

        EndMission();
    }

    private string GetTimeString()
    {
        if (_timeLeft < 0)
        {
            return "0:0";
        }
        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);

        return string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    private void MissionFailed()
    {
        LoseScreen.instance.Lose();
    }
}
