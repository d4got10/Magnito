using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CustomButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent OnPressed;
    public UnityEvent OnReleased;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        OnPressed.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnReleased.Invoke();
    }
}
