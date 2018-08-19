using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using TMPro;
using UnityEngine.UI;

public class InputTest : MonoBehaviour
{
    [SerializeField] private XboxController m_Controller;
    [SerializeField] private float m_PositionOffset;
    
    [Header("Stick")]
    [SerializeField] private TextMeshProUGUI m_Text;
    [SerializeField] private RectTransform m_Transform;

    [Header("buttons")]
    [SerializeField] Image[] m_Buttons;
    [SerializeField] TextMeshProUGUI[] m_Timers;


    private void Update()
    {    
        m_Text.text = ((int)GameManager.instance.InputManager.GetDirection(m_Controller).notation).ToString();
        m_Transform.localPosition = Vector3.zero + (Vector3)GameManager.instance.InputManager.GetDirection(m_Controller).direction * m_PositionOffset;

        for (int i = 0; i < m_Buttons.Length; i++)
        {
            m_Timers[i].text = GameManager.instance.InputManager.GetButtonHeldTime(m_Controller, Button.Button1 + i).ToString();
            if (GameManager.instance.InputManager.GetButtonState(m_Controller, Button.Button1 + i) == ButtonState.Down || GameManager.instance.InputManager.GetButtonState(m_Controller, Button.Button1 + i) == ButtonState.Held)
            {
                m_Buttons[i].color = new Color(0.5f, 0.5f, 0.5f);
            }
            else
            {
                m_Buttons[i].color = new Color(1, 1, 1);
            }
        }
    }
}
