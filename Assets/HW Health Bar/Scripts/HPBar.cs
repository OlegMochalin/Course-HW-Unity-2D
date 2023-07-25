using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
public class HPBar : MonoBehaviour
{
    [SerializeField] private float _barChangeTime = 0.5f;

    private float _hitPointsValueMin = 0;
    private float _hitPointsValueMax = 100;
    private float targetValue;
    private HitPoints _hitPoints;
    private Coroutine _activeCoroutine;

    private void Awake()
    {
        _hitPoints = GetComponentInParent<HitPoints>();
        GetComponent<Slider>().minValue = _hitPointsValueMin;
        GetComponent<Slider>().maxValue = _hitPointsValueMax;
        GetComponent<Slider>().value = _hitPoints.HitPointsPercent;
    }

    public void Update()
    {
        if (targetValue != _hitPoints.HitPointsPercent)
        {
            targetValue = _hitPoints.HitPointsPercent;

            if (_activeCoroutine != null)
            {
                StopCoroutine(_activeCoroutine);
            }
                
            _activeCoroutine = StartCoroutine(ChangeVolume(targetValue));
        }
    }

    private IEnumerator ChangeVolume(float targetValue)
    {
        float startValue = GetComponent<Slider>().value;
        float runTime = 0;

        while (runTime < _barChangeTime)
        {
            runTime += Time.deltaTime;
            GetComponent<Slider>().value = Mathf.Lerp(startValue, targetValue, runTime / _barChangeTime);

            yield return null;
        }
    }
}