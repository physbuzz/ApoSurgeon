using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* Code from https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.IDragHandler.html */
[RequireComponent(typeof(Image))]
public class DraggableTool : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool dragOnSurfaces = true;

    public Color hoverColor = new Color(1.0f,1.0f,0.0f);
    public Color draggingColor = new Color(0.1f,0.1f,0.1f,0.6f);

    
    public ToolType toolType;

    private GameObject m_DraggingIcon;
    
    private RectTransform m_DraggingPlane;
    private bool m_isDragging=false;


    public void OnBeginDrag(PointerEventData eventData)
    {
        var canvas = FindInParents<Canvas>(gameObject);
        if (canvas == null)
            return;

        m_isDragging = true;

        // We have clicked something that can be dragged.
        // What we want to do is create an icon for this.

        GetComponent<SpriteRenderer>().color = draggingColor;

        m_DraggingIcon = new GameObject("icon");

        m_DraggingIcon.transform.SetParent(canvas.transform, false);
        m_DraggingIcon.transform.SetAsLastSibling();

        var image = m_DraggingIcon.AddComponent<Image>();

        image.sprite = GetComponent<Image>().sprite;
        //image.SetNativeSize();
        //TODO: right now the image aspect ratio is messed up on drag.
        //Fix it here.

        if (dragOnSurfaces)
            m_DraggingPlane = transform as RectTransform;
        else
            m_DraggingPlane = canvas.transform as RectTransform;

        SetDraggedPosition(eventData);
    }

    public void OnDrag(PointerEventData data)
    {
        if (m_DraggingIcon != null)
            SetDraggedPosition(data);
    }

    private void SetDraggedPosition(PointerEventData data)
    {
        if (dragOnSurfaces && data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
            m_DraggingPlane = data.pointerEnter.transform as RectTransform;

        var rt = m_DraggingIcon.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
            rt.rotation = m_DraggingPlane.rotation;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (m_DraggingIcon != null)
            Destroy(m_DraggingIcon);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        m_isDragging = false;

        GameManager.instance.OnToolDragReleased(toolType);
    }

    static public T FindInParents<T>(GameObject go) where T : Component
    {
        if (go == null) return null;
        var comp = go.GetComponent<T>();

        if (comp != null)
            return comp;

        Transform t = go.transform.parent;
        while (t != null && comp == null)
        {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!m_isDragging)
            GetComponent<SpriteRenderer>().color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!m_isDragging)
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}