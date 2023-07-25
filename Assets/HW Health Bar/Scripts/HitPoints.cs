using UnityEngine;

public class HitPoints : MonoBehaviour
{
    private float _hitPointsMin = 0;
    private float _hitPointsMax = 100;
    private float _hitPoints;

    public float HitPointsPercent => _hitPoints / _hitPointsMax * 100; 

    private void Awake()
    {
        _hitPoints = _hitPointsMax;
    }

    public void Heal(float healValue)
    {
         _hitPoints += healValue;

        if (_hitPoints >= _hitPointsMax)
        {
            _hitPoints = _hitPointsMax;
        }
    }

    public void GetDamage(float damage)
    {
        _hitPoints -= damage;

        if (_hitPoints <= _hitPointsMin)
        {
            _hitPoints = _hitPointsMin;
        }
    }
}