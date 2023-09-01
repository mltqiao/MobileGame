using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tools : MonoBehaviour
{
    public static bool IfInNamedUI(string uiName)
    {
        var graphicRaycaster = FindObjectsOfType<GraphicRaycaster>();
        var eventData = new PointerEventData(EventSystem.current)
        {
            pressPosition = Input.mousePosition,
            position = Input.mousePosition
        };
        var list = new List<RaycastResult>();
        foreach (var item in graphicRaycaster)
        {
            item.Raycast(eventData, list);
            if (list.Count > 0 && list[0].gameObject.name == uiName)
            {
                return true;
            }
        }
        return false;
    }
}
