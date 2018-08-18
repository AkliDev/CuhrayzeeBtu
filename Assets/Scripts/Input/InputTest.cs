using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using TMPro;

public class InputTest : MonoBehaviour
{
    [SerializeField] private XboxController m_Controller;
    [SerializeField] private float m_PositionOffset;

    private TextMeshProUGUI m_Text;
    private RectTransform m_Transform;

    private void Awake()
    {
        m_Text = GetComponent<TextMeshProUGUI>();
        m_Transform = GetComponent<RectTransform>();
    }
    private void Update()
    {    
        m_Text.text = ((int)GameManager.instance.InputManager.GetDirection(m_Controller).notation).ToString();
        m_Transform.position = transform.parent.position + (Vector3)GameManager.instance.InputManager.GetDirection(m_Controller).direction * m_PositionOffset;
    }
}
