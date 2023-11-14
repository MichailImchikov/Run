using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class JOtoch :  MonoBehaviour,  IPointerDownHandler,IDragHandler,IPointerUpHandler
{
    private float direction=0;
    private float start=0;
    public void OnPointerDown(PointerEventData eventData)
    {
        start=eventData.position.x;
    }
    public void OnDrag(PointerEventData eventData)
    {
        direction=eventData.position.x-start;
        if(direction!=0)
        {
            direction=direction/Math.Abs(direction);
        }
        else 
        {
            direction=0;
        }
        
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        direction=0;
    }
    public float GetDirection()
    {
        return direction;
    }
}
