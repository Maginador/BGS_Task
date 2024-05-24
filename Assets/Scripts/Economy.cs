using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Economy : MonoBehaviour
{

    public static Economy Instance;
    private int currency;
    [SerializeField] int initialCurrency = 100;
    UnityAction<int> onCurrencyChanged;
    void Awake()
    {
        if (Instance) Destroy(Instance);
        Instance = this;
    }

    private void Start()
    {
        SetCurrency(initialCurrency);

    }
    public void AddCurrencyListener(UnityAction<int> listener)
    {
        onCurrencyChanged += listener;
    }
    public void SetCurrency(int newCurrency)
    {
        currency = newCurrency;
        onCurrencyChanged?.Invoke(currency);

    }
    public void SpendCurrency(int change)
    {

        //TODO Add error and feedback
        if (currency - change < 0) return;
        currency -= change;
        onCurrencyChanged?.Invoke(currency);
    }


}
