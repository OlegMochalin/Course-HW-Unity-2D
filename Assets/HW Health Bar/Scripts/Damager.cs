using UnityEngine;

[RequireComponent (typeof(Health))]
public class Damager : MonoBehaviour
{
    private Health _hitPoints;
    private float _damageValue = 10f;

    private void Awake()
    {
        _hitPoints = GetComponent<Health>();
    }

    public void OnButonClick()
    {
        _hitPoints.GetDamage(_damageValue);
    }
}