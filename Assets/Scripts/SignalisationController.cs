using System.Collections;
using UnityEngine;

public class SignalisationController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _fadeDuration;

    private Coroutine _activeVolumeCoroutine;

    public void Awake()
    {
        _audioSource.volume = 0;
    }

    public void StartVolumeChange(bool IsRobberInside)
    {
        if (_activeVolumeCoroutine != null)
            StopCoroutine(_activeVolumeCoroutine);

        _activeVolumeCoroutine = StartCoroutine(ChangeVolume(IsRobberInside));
    }

    private IEnumerator ChangeVolume(bool IsRobberInside)
    {        
        float startVolume = _audioSource.volume;
        float targetVolume = IsRobberInside == true ? 1 : 0;
        float runTime = 0;

        if (IsRobberInside == true && _audioSource.isPlaying == false)
            _audioSource.Play();

        while (runTime < _fadeDuration)
        {
            runTime += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(startVolume, targetVolume, runTime / _fadeDuration);

            yield return null;
        }

        if (IsRobberInside == false && _audioSource.isPlaying == true)
            _audioSource.Stop();
    }
}