using UnityEngine;

public class Health : MonoBehaviour
{
    private float _healthMin = 0;
    private float _healthMax = 100;
    private float _health;

    public float HealthPercent => _health / _healthMax * 100; 

    private void Start()
    {
        _health = _healthMax;
    }

    public void Heal(float healValue)
    {
         _health += healValue;

        _health = Mathf.Clamp(_health, _healthMin, _healthMax);
    }

    public void GetDamage(float damage)
    {
        _health -= damage;

        _health = Mathf.Clamp(_health, _healthMin, _healthMax);
    }
}