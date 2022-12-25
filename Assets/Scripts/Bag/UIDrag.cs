using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDrag : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
{
    private Vector3 mousePosition;

    private RectTransform rect;

    public Action onStartDrag;
    public Action onDrag;
    public Action onEndDrag;

    private void Awake()
    {
        rect = transform.GetComponent<RectTransform>();
        if(rect == null)
        {
            throw new System.Exception("只能拖拽UI物体");
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        mousePosition = Input.mousePosition;
        if(onStartDrag != null) { onStartDrag(); }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += (Vector2)(Input.mousePosition - mousePosition);
        mousePosition = Input.mousePosition;
        if (onDrag != null) { onDrag(); }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (onEndDrag != null) { onEndDrag(); }
    }
}
