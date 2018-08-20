using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInput;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
 
    private InputManager m_Inputmanager;

    public InputManager InputManager { get { return m_Inputmanager; } }

    private void Init()
    {
        m_Inputmanager = new InputManager();
    }

    private void CreateInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Init();
        CreateInstance();
    }

    private void Update()
    {
        m_Inputmanager.Update();
    }

}

