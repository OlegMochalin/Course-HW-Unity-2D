using UnityEngine;

[RequireComponent (typeof(HitPoints))]
public class Healer : MonoBehaviour
{
    private HitPoints _hitPoints;
    private float _healValue = 10f;

    private void Awake()
    {
        _hitPoints = GetComponent<HitPoints>();
    }

    public void OnButonClick()
    {
        _hitPoints.Heal(_healValue);
    }
}