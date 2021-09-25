using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderChanger : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speedChangeSlider;

    private Slider _slider;
    private Coroutine _setValueJob;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.MaxHealth;
        _slider.minValue = _player.MinHealth;
    }

    private void OnEnable()
    {
        _player.HealthChanged += StartChangeSlider;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= StartChangeSlider;
    }

    private void StartChangeSlider(float value)
    {
        if (_setValueJob != null)
            StopCoroutine(_setValueJob);
        _setValueJob = StartCoroutine(ChangeSlider(value));
    }

    private IEnumerator ChangeSlider(float targetValue)
    {
        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _speedChangeSlider * Time.deltaTime);
            yield return null;
        }
    }
}
