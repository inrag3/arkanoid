using UnityEngine;

[CreateAssetMenu(fileName = "SpeedBonus", menuName = "Bonus/Speed", order = 51)]
public class SpeedBonus : BonusData
{
    [SerializeField, Range(0, 2)] private float _multiplier;
    public override void ExecuteAction(IBallController ballController)
    {
        ballController.SetSpeedMultiplier(_multiplier);
    }
}