using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GreenBlockScript : BlockScript
{
    [SerializeField] private Bonus _prefab;
    [SerializeField] private List<BonusData> _data;
    private IBonusProbabilities _bonusProbabilities;
    private Vector3 _position;

    public void Initialize(IBonusProbabilities bonusProbabilities)
    {
        _bonusProbabilities = bonusProbabilities;
        _position = transform.position;
    }
    protected override void Destroy()
    {
        int index = Random.Range(0, _data.Count);
        var bonusData = _data[index];
        if (!_bonusProbabilities.BonusProbabilities.TryGetValue(bonusData.GetType(), out float prob))
            return;
        float value = Random.value;

        if (value < prob)
        {
            var bonus = Instantiate(_prefab, _position, Quaternion.identity, null);
            bonus.Initialize(bonusData);
        }
        base.Destroy();
    }
}