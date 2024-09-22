using UnityEngine;

[CreateAssetMenu(fileName = "UpdateReserve", menuName = "Bonus/UpdateReserve", order = 51)]
public class UpdateReserve : BonusData
{
    [SerializeField, Min(1)] private int _count;

    public override void ExecuteAction(IBallController ballController)
    {
        ballController.UpdateReserve(_count);
    }
}