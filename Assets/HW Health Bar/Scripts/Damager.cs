using UnityEngine;

[RequireComponent (typeof(HitPoints))]
public class Damager : MonoBehaviour
{
    private HitPoints _hitPoints;
    private float _damageValue = 10f;

    private void Awake()
    {
        _hitPoints = GetComponent<HitPoints>();
    }

    public void OnButonClick()
    {
        _hitPoints.GetDamage(_damageValue);
    }
}