using UnityEngine;
using UnityEngine.Events;

public class Gem : MonoBehaviour
{
    [SerializeField] private UnityEvent _collected;

    public event UnityAction Collected
    {
        add => _collected.AddListener(value);
        remove => _collected.RemoveListener(value);
    }

    public bool IsCollected { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsCollected)
            return;

        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsCollected = true;
            _collected?.Invoke();
            Destroy(gameObject);
        }
    }
}