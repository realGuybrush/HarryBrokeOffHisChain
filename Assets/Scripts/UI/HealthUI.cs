using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private List<HeartUI> hearts;

    [SerializeField]
    private Vector3 offset;
    
    private int currentHeartIndex;

    private void Awake()
    {
        currentHeartIndex = hearts.Count - 1;
        for (int i = 1; i < hearts.Count; i++)
        {
            hearts[i].transform.position = hearts[i - 1].transform.position + offset;
        }
    }

    public void Heal(int amount)
    {
        currentHeartIndex++;
        while (amount > 0 && currentHeartIndex < hearts.Count)
        {
            hearts[currentHeartIndex].Heal();
            currentHeartIndex++;
            amount--;
        }
    }

    public void GetDamaged(int amount)
    {
        while (amount > 0 && currentHeartIndex > -1)
        {
            hearts[currentHeartIndex].GetDamaged();
            currentHeartIndex--;
            amount--;
        }
    }
}