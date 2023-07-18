using UnityEngine;

[RequireComponent(typeof(SignalisationController))]
public class RobberDetector : MonoBehaviour
{
    private bool _isRobberInside;
    private SignalisationController _signalisationController;

    public void Awake()
    {
        _signalisationController = GetComponent<SignalisationController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Robber>(out Robber robber))
        {
            _isRobberInside = true;
            _signalisationController.StartVolumeChange(_isRobberInside);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Robber>(out Robber robber))
        {
            _isRobberInside = false;
            _signalisationController.StartVolumeChange(_isRobberInside);
        }
    }
}