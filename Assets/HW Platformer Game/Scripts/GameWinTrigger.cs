using UnityEngine;

public class GameWinTrigger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _endGameBanner;
    [SerializeField] private SpriteRenderer _endGameText;

    private Gem[] _gems;

    private void Awake()
    {
        _endGameBanner.GetComponent<SpriteRenderer>().enabled = false;
        _endGameText.GetComponent<SpriteRenderer>().enabled = false;

        _gems = gameObject.GetComponentsInChildren<Gem>();

        foreach (var gem in _gems)
        {
            gem.Collected += OnGemCollected;
        }
    }

    private void OnDisable()
    {
        foreach (var gem in _gems)
        {
            gem.Collected -= OnGemCollected;
        }
    }

    private void OnGemCollected()
    {
        foreach(var gem in _gems)
        {
            if (gem.IsCollected == false)
                return;
        }

        Time.timeScale = 0;

        _endGameBanner.GetComponent<SpriteRenderer>().enabled = true;
        _endGameText.GetComponent<SpriteRenderer>().enabled = true;
    }
}