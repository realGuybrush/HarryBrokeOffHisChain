using System;
using TMPro;
using UnityEngine;

public class UICounter : MonoBehaviour
{
    private int countable;

    [SerializeField]
    private TextMeshProUGUI text;
    
    public event Action OnTextChange = delegate { };

    public void AddCountable(int amount)
    {
        countable += amount;
        text.text = countable.ToString();
        OnTextChange?.Invoke();
    }
}