using TMPro;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Bonus : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private SpriteRenderer _spriteRenderer;
    private BonusData _data;
    public void Initialize(BonusData data)
    {
        _data = data;
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = _data.BackgroundColor;
        _text.color = _data.TextColor;
        _text.text = _data.Name;
    }

    private void Update()
    {
        transform.position += Vector3.down * (Time.deltaTime * 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out IBallController ballController))
        {
            _data.ExecuteAction(ballController);
        }
        Destroy(gameObject);
    }
}