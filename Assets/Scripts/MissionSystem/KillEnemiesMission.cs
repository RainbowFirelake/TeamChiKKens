using UnityEngine;

public class KillEnemiesMission : BaseMission
{
    [SerializeField]
    private int _killCountToComplete = 5;
    [SerializeField]
    private string _missionInfo;
    private int _currentKilledEnemyCount = 0;

    public override void StartMission()
    {
        Health.OnDie += CheckEnemyDie;
        OnMissionStartInvoke(_missionInfo);
        OnMissionCompetionUpdateInvoke(_currentKilledEnemyCount + "/" + _killCountToComplete);
    }

    public override void EndMission()
    {
        Health.OnDie -= CheckEnemyDie;
        OnMissionEndInvoke();
    }

    private void CheckEnemyDie(Side side)
    {
        if (side == Side.Enemy)
        {
            _currentKilledEnemyCount++;
            OnMissionCompetionUpdateInvoke(_currentKilledEnemyCount + "/" + _killCountToComplete);
            if (_currentKilledEnemyCount >= _killCountToComplete)
            {
                EndMission();
            }
        }
    }
}