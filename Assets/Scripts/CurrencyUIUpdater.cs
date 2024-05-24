using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyUIUpdater : MonoBehaviour
{
    [SerializeField] TMP_Text currencyField;

    private void Start()
    {
        Economy.Instance.AddCurrencyListener(OnCurrencyUpdated);
    }

    private void OnCurrencyUpdated(int currency)
    {
        currencyField.text = currency.ToString();
    }
}
