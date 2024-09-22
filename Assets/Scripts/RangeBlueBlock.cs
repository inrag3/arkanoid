using UnityEngine;

public class RangeBlueBlock : BlockScript
{
    [SerializeField, Min(0.1f)] private float _speed;

    private (float, float) _range;

    private Vector3 _start;
    private float _target;

    public void Initialize(float left, float right)
    {
        _range = (left, right);
        _start = transform.position;
        _target = left;
    }

    private void Update()
    {
        var newPosition = new Vector3(
            Mathf.MoveTowards(transform.position.x, _target, _speed * Time.deltaTime),
            _start.y,
            _start.z
        );

        transform.position = newPosition;

        if (Mathf.Abs(transform.position.x - _target) < 0.1f)
        {
            _target = Mathf.Approximately(_target, _range.Item2) ? _range.Item1 : _range.Item2;
        }
    }

}