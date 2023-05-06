using UnityEngine;

public class CraftMission : BaseMission
{
    [SerializeField]
    private CraftType _neededItem;

    void OnEnable()
    {
        CraftStation.OnCraft += CheckCraft;
    }

    public override void EndMission()
    {
        CraftStation.OnCraft -= CheckCraft;
        OnMissionEndInvoke();
        EnableObjectsWhenEndMission();
        this.gameObject.SetActive(false);
    }   

    public override void StartMission()
    {
        EnableObjectsOnStartMission();
        OnMissionCompletionUpdateInvoke("0/1");
        OnMissionStartInvoke(_missionInfo);
    }

    public void CheckCraft(CraftType type)
    {
        if (type == _neededItem)
        {
            EndMission();
        }
    }
}