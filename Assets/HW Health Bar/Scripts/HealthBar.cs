using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _barChangeTime = 0.5f;

    private float _healthPercentMin = 0;
    private float _healthPercentMax = 100;
    private float targetValue;

    private Slider _healthBarSlider;        

    private Coroutine _activeCoroutine;

    private void Awake()
    {
        _healthBarSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        _healthBarSlider.minValue = _healthPercentMin;
        _healthBarSlider.maxValue = _healthPercentMax;
        _healthBarSlider.value = _health.HealthPercent;        
    }

    public void OnButtonClick()
    {
        if (targetValue != _health.HealthPercent)
        {
            targetValue = _health.HealthPercent;

            if (_activeCoroutine != null)
            {
                StopCoroutine(_activeCoroutine);
            }
                
            _activeCoroutine = StartCoroutine(ChangeHPBarFilling(targetValue));
        }
    }

    private IEnumerator ChangeHPBarFilling(float targetValue)
    {
        float startValue = _healthBarSlider.value;
        float runTime = 0;

        while (runTime < _barChangeTime)
        {
            runTime += Time.deltaTime;
            _healthBarSlider.value = Mathf.Lerp(startValue, targetValue, runTime / _barChangeTime);

            yield return null;
        }
    }
}