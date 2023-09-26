using UnityEngine;

namespace HWRunnerGame
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _damage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                player.ApplyDamage(_damage);
            }

            TurnOff();
        }

        private void TurnOff()
        {
            gameObject.SetActive(false);
        }
    }
}