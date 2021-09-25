using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform), typeof(Image))]
public class Button : MonoBehaviour
{
    [SerializeField] private float _speedChangeScale;
    [SerializeField] private float _targetValue;
    [SerializeField] private Color _targetColor;

    private RectTransform _rectTransform;
    private Image _image;
    private Color _defaultColor;
    private Coroutine _setScaleJob;
    
    public void OnButtonClick()
    {
        if (_setScaleJob != null)
            StopCoroutine(_setScaleJob);
        _setScaleJob = StartCoroutine(SetScale(_targetValue));
    }

    private IEnumerator SetScale(float targetValue)
    {
        Vector3 vector = _rectTransform.transform.localScale;
        _image.color = _targetColor;
        while (vector.x != targetValue)
        {
            vector.x = Mathf.MoveTowards(vector.x, targetValue, _speedChangeScale * Time.deltaTime);
            vector.y = Mathf.MoveTowards(vector.y, targetValue, _speedChangeScale * Time.deltaTime);
            _rectTransform.transform.localScale = vector;
            if (vector.x == targetValue)
                targetValue = 1;
            yield return null;
        }
        _image.color = _defaultColor;
    }

    private void Start()
    {
        _image = GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();
        _defaultColor = _image.color;
    }
}
