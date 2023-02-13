using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectedView : MonoBehaviour
{
    [SerializeField]
    private float m_speed = 25f;
    private RectTransform m_rectTransform;
    private GameObject m_selected;

    private void Awake()
    {
        m_rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        var selectedGameObject = EventSystem.current.currentSelectedGameObject;

        m_selected = (selectedGameObject == null) ? m_selected : selectedGameObject;
        
        EventSystem.current.SetSelectedGameObject(m_selected);

        if (m_selected == null) return;

        transform.position = Vector3.Lerp(transform.position, m_selected.transform.position, m_speed * Time.deltaTime);

        var otherRect = m_selected.GetComponent<RectTransform>();

        var horizontalLerp = Mathf.Lerp(m_rectTransform.rect.size.x, otherRect.rect.size.x, m_speed * Time.deltaTime);
        var verticalLerp = Mathf.Lerp(m_rectTransform.rect.size.y, otherRect.rect.size.y, m_speed * Time.deltaTime);

        m_rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, horizontalLerp);
        m_rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, verticalLerp);
    }
}
