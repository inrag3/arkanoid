using UnityEngine;

[CreateAssetMenu(fileName = "UpdateReserveImmediately", menuName = "Bonus/UpdateReserveImmediately", order = 51)]
public class UpdateReserveImmediately : BonusData
{
    [SerializeField] private int _count;

    public override void ExecuteAction(IBallController ballController)
    {
        ballController.UpdateReserveImmediately(_count);
    }
}