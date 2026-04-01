using UnityEngine;

public class AdjustTextPosition : MonoBehaviour
{
    [SerializeField]
    private UICounter uiCounter;

    [SerializeField]
    private Vector3 defaultOffset;
    private void Awake()
    {
        uiCounter.OnTextChange += AdjustPosition;
    }
    private void OnDestroy()
    {
        uiCounter.OnTextChange -= AdjustPosition;
    }

    private void AdjustPosition()
    {
        transform.position = uiCounter.transform.position + defaultOffset;
    }
}
