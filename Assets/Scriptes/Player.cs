using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;

    public event UnityAction<float> HealthChanged;

    public float MaxHealth
    {
        get { return _maxHealth; }
    }

    public float MinHealth
    {
        get { return _minHealth; }
    }

    public void AddHealth(float stepChangeHealth)
    {
        _health += stepChangeHealth;
        if (_health > _maxHealth)
            _health = _maxHealth;
        HealthChanged?.Invoke(_health);
    }

    public void SubHealth(float stepChangeHealth)
    {
        _health -= stepChangeHealth;
        if (_health < _minHealth)
            _health = _minHealth;
        HealthChanged?.Invoke(_health);
    }  
}
