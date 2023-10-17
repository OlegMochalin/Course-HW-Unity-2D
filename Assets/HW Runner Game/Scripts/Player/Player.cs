using UnityEngine;
using UnityEngine.Events;

namespace HWRunnerGame
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _health;

        public event UnityAction<float> HealthChanged;
        public event UnityAction Died;


        private void Start()
        {
            HealthChanged?.Invoke(_health);
        }

        public void ApplyDamage(float damage)
        {
            _health -= damage;
            HealthChanged?.Invoke(_health);

            if (_health <= 0)
                Die();
        }

        public void Heal(float healAmount)
        {
            _health += healAmount;
            HealthChanged?.Invoke(_health);
        }

        public void Die()
        {
            Died?.Invoke();
        }
    }
}