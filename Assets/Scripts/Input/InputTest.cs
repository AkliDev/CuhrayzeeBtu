using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
using TMPro;
using UnityEngine.UI;
using GameInput;


public class InputTest : MonoBehaviour
{
    [SerializeField] private XboxController m_Controller;
    [SerializeField] private float m_PositionOffset;
    
    [Header("Stick")]
    [SerializeField] private TextMeshProUGUI m_DirectionText;
    [SerializeField] private TextMeshProUGUI m_TimerText;
    [SerializeField] private RectTransform m_Transform;

    [Header("buttons")]
    [SerializeField] Image[] m_Buttons;
    [SerializeField] TextMeshProUGUI[] m_Timers;


    private void Update()
    {
        InputDirection inputDirection = GameManager.instance.InputManager.GetDirection(m_Controller);
        m_DirectionText.text = ((int)inputDirection.notation).ToString();
        m_TimerText.text = inputDirection.heldTime.ToString();
        m_Transform.localPosition = Vector3.zero + (Vector3)GameManager.instance.InputManager.GetDirection(m_Controller).direction * m_PositionOffset;

        for (int i = 0; i < m_Buttons.Length; i++)
        {
            m_Timers[i].text = GameManager.instance.InputManager.GetButtonHeldTime(m_Controller, VButton.Button1 + i).ToString();

            if (GameManager.instance.InputManager.CheckIsButtonPressed(m_Controller, VButton.Button1 + i) == IsButtonPressed.IsPressed)
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
