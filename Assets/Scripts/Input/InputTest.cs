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
    [SerializeField] private RectTransform m_Transform;

    [Header("buttons")]
    [SerializeField] Image[] m_Buttons;
    [SerializeField] TextMeshProUGUI[] m_Timers;

    [Header("Buffer")]
    [SerializeField] Sprite m_Arrow;
    Image[] m_BufferImage;
    TextMeshProUGUI[] m_BufferTimers;



    private void Awake()
    {
        GameObject image = new GameObject();
        image.AddComponent<Image>();

        GameObject timer = new GameObject();
        timer.AddComponent<TextMeshProUGUI>();


        m_BufferImage = new Image[GameManager.instance.InputManager.GetInputBuffer(m_Controller).Length];
        m_BufferTimers = new TextMeshProUGUI[m_BufferImage.Length];

        for (int i = 0; i < m_BufferImage.Length; i++)
        {
            m_BufferImage[i] = Instantiate(image, this.transform).GetComponent<Image>();
            m_BufferImage[i].rectTransform.localPosition = new Vector2(-335, 15 - i * 50);
            m_BufferImage[i].rectTransform.sizeDelta = new Vector2(40, 40);
            m_BufferImage[i].color = new Color(1, 1, 1, 0);
            m_BufferImage[i].sprite = m_Arrow;

            m_BufferTimers[i] = Instantiate(timer, this.transform).GetComponent<TextMeshProUGUI>();
            m_BufferTimers[i].fontSize = 15;
            m_BufferTimers[i].rectTransform.localPosition = (Vector2)m_BufferImage[i].rectTransform.localPosition + new Vector2(150, -20);
        }
    }

    private void Update()
    {
        m_DirectionText.text = ((int)GameManager.instance.InputManager.GetDirection(m_Controller).notation).ToString();
        m_Transform.localPosition = (Vector2)GameManager.instance.InputManager.GetDirection(m_Controller).direction * m_PositionOffset;

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

        for (int i = 0; i < m_BufferImage.Length; i++)
        {
            m_BufferTimers[i].text = GameManager.instance.InputManager.GetInputBuffer(m_Controller)[i].heldTime.ToString();

            switch (GameManager.instance.InputManager.GetInputBuffer(m_Controller)[i].notation)
            {
                case DirectionNotaton.Left:
                    m_BufferImage[i].color = new Color(1, 0, 1, 1);
                    m_BufferImage[i].rectTransform.localEulerAngles = new Vector3(0, 0, 0);
                    break;
                case DirectionNotaton.DownLeft:
                    m_BufferImage[i].color = new Color(0, 1, 1, 1);
                    m_BufferImage[i].rectTransform.localEulerAngles = new Vector3(0, 0, 45);
                    break;
                case DirectionNotaton.Down:
                    m_BufferImage[i].color = new Color(1, 1, 0, 1);
                    m_BufferImage[i].rectTransform.localEulerAngles = new Vector3(0, 0, 90);
                    break;
                case DirectionNotaton.DownRight:
                    m_BufferImage[i].color = new Color(0, 0, 1, 1);
                    m_BufferImage[i].rectTransform.localEulerAngles = new Vector3(0, 0, 135);
                    break;
                case DirectionNotaton.Right:
                    m_BufferImage[i].color = new Color(1, 0, 0, 1);
                    m_BufferImage[i].rectTransform.localEulerAngles = new Vector3(0, 0, 180);
                    break;
                case DirectionNotaton.UpRight:
                    m_BufferImage[i].color = new Color(0, 1, 0, 1);
                    m_BufferImage[i].rectTransform.localEulerAngles = new Vector3(0, 0, 225);
                    break;
                case DirectionNotaton.Up:
                    m_BufferImage[i].color = new Color(0.6f, 1, 0.2f, 1);
                    m_BufferImage[i].rectTransform.localEulerAngles = new Vector3(0, 0, 270);
                    break;
                case DirectionNotaton.UpLeft:
                    m_BufferImage[i].color = new Color(1, 1, 1, 1);
                    m_BufferImage[i].rectTransform.localEulerAngles = new Vector3(0, 0, 315);
                    break;
            }
        }
    }
}
