using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.GetComponent<PlayerController>().GetHit();
        }
    }
}
