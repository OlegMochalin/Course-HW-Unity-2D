using UnityEngine;

namespace HWRunnerGame
{
    public class Healer : MonoBehaviour
    {
        [SerializeField] private float _healAmount;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                player.Heal(_healAmount);
            }

            TurnOff();
        }

        private void TurnOff()
        {
            gameObject.SetActive(false);
        }
    }
}