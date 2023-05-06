using UnityEngine;

public class DestroyEnemyHQMission : BaseMission
{
    void OnEnable()
    {
        PlayerHeadQuarters.OnDestroyPlayerHQ += CheckMissionFail;
        EnemyHeadquarters.OnDestroyEnemyHQ += CheckMissionWin;
    }

    void OnDisable()
    {
        PlayerHeadQuarters.OnDestroyPlayerHQ -= CheckMissionFail;
        EnemyHeadquarters.OnDestroyEnemyHQ -= CheckMissionWin;
    }

    public override void StartMission()
    {
        OnMissionStartInvoke(_missionInfo);
        EnableObjectsOnStartMission();
    }

    public override void EndMission()
    {
        OnMissionEndInvoke();
        EnableObjectsWhenEndMission();
    }

    private void CheckMissionWin()
    {
        WinScreen.instance.Win();
    }

    private void CheckMissionFail()
    {
        LoseScreen.instance.Lose();
    }
}