using UnityEngine;

public class EnemyToTargetMover : MonoBehaviour
{
    [SerializeField] private EnemySpawner _target;

    private void Awake()
    {
        _target = FindObjectOfType<EnemySpawner>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.GetComponent<Transform>().position, 0.05f);
    }
}