using UnityEngine;

[RequireComponent (typeof(Health))]
public class Healer : MonoBehaviour
{
    private Health _hitPoints;
    private float _healValue = 10f;

    private void Awake()
    {
        _hitPoints = GetComponent<Health>();
    }

    public void OnButtonClick()
    {
        _hitPoints.Heal(_healValue);
    }
}