using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    [SerializeField] private float _speed = 0.05f;

    private Coroutine _currentCoroutine;
    public void OnValueChanged( int value, int maxValue)
    {
        float target = (float)value / maxValue;

        if (_currentCoroutine != null)
           StopCoroutine(_currentCoroutine); 

     _currentCoroutine = StartCoroutine(ChangeValue(_speed, target));
    }

    private IEnumerator ChangeValue(float speed, float target)
    {
        
        while (Slider.value!=target)
        {
           Slider.value =  Mathf.MoveTowards(Slider.value, target, speed * Time.deltaTime);

            yield return null;
        }
    }
}
