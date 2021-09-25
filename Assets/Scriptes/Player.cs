using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _stepChangeHealth;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private float _speedChangeSlider;

    private Coroutine _setValueJob;
    
    public void AddHealth()
    {
        _health += _stepChangeHealth;
        if (_health > _maxHealth)
            _health = _maxHealth;
        StartChangeSlider();
    }

    public void SubHealth()
    {
        _health -= _stepChangeHealth;
        if (_health < _minHealth)
            _health = _minHealth;
        StartChangeSlider();
    }

    private void StartChangeSlider()
    {
        if (_setValueJob != null)
            StopCoroutine(_setValueJob);
        _setValueJob = StartCoroutine(ChangeSlider(_health));
    }

    private IEnumerator ChangeSlider(float targetValue)
    {
        while (_healthSlider.value != targetValue)
        {
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, targetValue, _speedChangeSlider * Time.deltaTime);
            yield return null;
        }
    }

    private void Start()
    {
        _healthSlider.maxValue = _maxHealth;
        _healthSlider.minValue = _minHealth;
        _healthSlider.value = _health;
    }
}
