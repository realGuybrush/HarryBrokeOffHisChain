using System;
using UnityEngine;

public class LandTrigger : MonoBehaviour
{
    private bool airborne = true;
    public event Action OnLand = delegate { };

    private void OnTriggerEnter2D(Collider2D other)
    {
        airborne = false;
        OnLand?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        airborne = true;
    }

    public bool IsAirborne => airborne;
}