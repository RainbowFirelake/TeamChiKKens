using UnityEngine;

public class KillEnemiesMission : BaseMission
{
    [SerializeField]
    private int _killCountToComplete = 5;
    
    private int _currentKilledEnemyCount = 0;

    public override void StartMission()
    {
        Health.OnEnemyDie += CheckEnemyDie;
        OnMissionStartInvoke(_missionInfo);
        EnableObjectsOnStartMission();
        OnMissionCompletionUpdateInvoke(_currentKilledEnemyCount + "/" + _killCountToComplete);
    }

    public override void EndMission()
    {
        Health.OnEnemyDie -= CheckEnemyDie;
        OnMissionEndInvoke();
        EnableObjectsWhenEndMission();
        this.gameObject.SetActive(false);
    }

    private void CheckEnemyDie(Side side)
    {
        if (side == Side.Enemy)
        {
            _currentKilledEnemyCount++;
            OnMissionCompletionUpdateInvoke(_currentKilledEnemyCount + "/" + _killCountToComplete);
            if (_currentKilledEnemyCount >= _killCountToComplete)
            {
                EndMission();
            }
        }
    }
}