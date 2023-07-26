using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _barChangeTime = 0.5f;

    private float _healthValueMin = 0;
    private float _healthValueMax = 100;
    private float targetValue;

    private Slider _healthBarSlider;        

    private Coroutine _activeCoroutine;

    private void Awake()
    {
        _healthBarSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        _healthBarSlider.minValue = _healthValueMin;
        _healthBarSlider.maxValue = _healthValueMax;
        _healthBarSlider.value = _health.HealthPercent;        
    }

    public void Update()
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
        float startValue = GetComponent<Slider>().value;
        float runTime = 0;

        while (runTime < _barChangeTime)
        {
            runTime += Time.deltaTime;
            _healthBarSlider.value = Mathf.Lerp(startValue, targetValue, runTime / _barChangeTime);

            yield return null;
        }
    }
}