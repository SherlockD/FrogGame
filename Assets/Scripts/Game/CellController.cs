using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellController : MonoBehaviour, IPointerClickHandler
{
    public FrogController FrogController { get; set; }

    public event Action<CellController> OnPointerClockCallback;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnPointerClockCallback?.Invoke(this);
    }
}
