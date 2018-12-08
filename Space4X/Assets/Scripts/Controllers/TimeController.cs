using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeController : MonoBehaviour
{

    public static TimeController Instance;

    public float CurrentTime { get; protected set; }

    public bool IsPaused { get; private set; }

    public event Action<float> OnTick;
    public event Action<bool, Speed> OnTimeScaleChanged;

    public enum Speed
    {
        Normal,
        Fast,
        Faster,
        Fastest
    }
    public Speed CurrentSpeed { get; protected set; }


    public void Pause()
    {
        IsPaused = true;
        Time.timeScale = 0f;
        RaiseTimeScaleChangedEvent();
    }

    public void Resume()
    {
        IsPaused = false;
        Time.timeScale = TimeScales[CurrentSpeed];
        RaiseTimeScaleChangedEvent();
    }

    public void TogglePause()
    {
        if (IsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    public void SetSpeed(Speed speed)
    {
        CurrentSpeed = speed;
        Resume();
        RaiseTimeScaleChangedEvent();
    }

    public void SetSpeed(int speed)
    {
        SetSpeed((Speed)speed);
    }

    protected static Dictionary<Speed, float> TimeScales = new Dictionary<Speed, float>()
    {
        { Speed.Normal,  1f},
        { Speed.Fast,    1.5f},
        { Speed.Faster,  5f},
        { Speed.Fastest, 10f}
    };
    protected float TimeScale;

    protected void RaiseTimeScaleChangedEvent()
    {
        if (OnTimeScaleChanged != null)
        {
            OnTimeScaleChanged(IsPaused, CurrentSpeed);
        }
    }

	private void OnEnable()
	{
	    if (Instance == null)
	    {
	        Instance = this;
	    }
	    else if (Instance != this)
	    {
	        Debug.LogError("Multiple TimeManagers in scene!");
            gameObject.SetActive(false);
	    }
	}

    private void Update()
    {
        if (IsPaused)
        {
            return;
        }

        CurrentTime += Time.deltaTime;

        if (OnTick != null)
        {
            OnTick(Time.deltaTime);
        }
    }
}
