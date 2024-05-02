using System.Collections;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _number;

    private WaitForSeconds _delay = new(0.5f);
    private int _currentValue;
    private Coroutine _increaseNumber;
    private KeyCode _activationButton = KeyCode.Space;
    private bool _isWork;

    private void Start()
    {
        _number.SetText(_currentValue.ToString());
        _increaseNumber = StartCoroutine(nameof(CountNumbers));
    }

    private void Update()
    {
        if (Input.GetKeyDown(_activationButton) && _isWork == false)
        {
            _isWork = true;
            _increaseNumber = StartCoroutine(nameof(CountNumbers));
        }
        else if (Input.GetKeyDown(_activationButton) && _isWork == true)
        {
            _isWork = false;
            StopCoroutine(_increaseNumber);
        }
    }

    private void OnDisable()
    {
        StopCoroutine(_increaseNumber);
    }

    private IEnumerator CountNumbers()
    {
        while (_isWork)
        {
            _currentValue++;
            _number.SetText(_currentValue.ToString());
            yield return _delay;
        }
    }
}