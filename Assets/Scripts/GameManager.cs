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
        Init();
        CreateInstance();
    }

    private void Update()
    {
        m_Inputmanager.Update();
    }

}

class test
{
    #region UPDATE

    void Update()
    {
        if (isPlaying)
        {
            ExecuteOnPlayerUpdate();
            ExecuteOnNpcUpdate();
            ExecuteOnMiscUpdate();
        }
    }

    #endregion


    #region GAME STATES
    private enum GameState
    {
        None,
        IsPlaying,
        IsPaused,
        IsStopped
    }

    private GameState state;

#if UNITY_EDITOR || DEVELOPMENT_BUILD
    private string currentState;
#endif

    public void Play()
    {
        if (state != GameState.IsPlaying)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            Debug.Log("GAME PLAYING");
            currentState = "GAME PLAYING";
#endif

            state = GameState.IsPlaying;
            ExecuteOnPlaying();
            Time.timeScale = 1f;
        }
    }

    public void Pause()
    {
        if (state != GameState.IsPaused)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            Debug.Log("GAME PAUSED");
            currentState = "GAME PAUSED";
#endif

            state = GameState.IsPaused;
            ExecuteOnPausing();
            Time.timeScale = 0f;
        }
    }

    public void Stop()
    {
        if (state != GameState.IsStopped)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            Debug.Log("GAME STOPPED");
            currentState = "GAME STOPPED";
#endif

            state = GameState.IsStopped;
            ExecuteOnStopping();
            Time.timeScale = 1f;
        }
    }

    #endregion


    #region GAME EVENTS

    public delegate void GameEvent();
    public GameEvent OnPlaying; // normal gameplay
    public GameEvent OnPausing; // game paused
    public GameEvent OnStopping; // scripted non-playable event

    void ExecuteOnPlaying()
    {
        if (OnPlaying != null)
        {
            OnPlaying();
        }
    }

    void ExecuteOnPausing()
    {
        if (OnPausing != null)
        {
            OnPausing();
        }
    }

    void ExecuteOnStopping()
    {
        if (OnStopping != null)
        {
            OnStopping();
        }
    }

    #endregion


    #region UPDATE EVENTS

    public delegate void UpdateEvent();
    public UpdateEvent OnPlayerUpdate; // updating states for player characters
    public UpdateEvent OnNpcUpdate; // updating states for non-player characters
    public UpdateEvent OnMiscUpdate; // updating states for everything else

    void ExecuteOnPlayerUpdate()
    {
        if (OnPlayerUpdate != null)
        {
            OnPlayerUpdate();
        }
    }
    #endregion
}
