using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeedPanel : MonoBehaviour
{
    [SerializeField] protected ButtonToggle PauseToggle;
    [SerializeField] protected ButtonToggle NormalToggle;
    [SerializeField] protected ButtonToggle FastToggle;
    [SerializeField] protected ButtonToggle FasterToggle;
    [SerializeField] protected ButtonToggle FastestToggle;

    private void Start()
    {
        TimeController.Instance.OnTimeScaleChanged += OnTimeScaleChanged;
        OnTimeScaleChanged(TimeController.Instance.IsPaused, TimeController.Instance.CurrentSpeed);
    }


    protected void OnTimeScaleChanged(bool isPaused, TimeController.Speed speed)
    {
        PauseToggle.SetToggle(isPaused);

        NormalToggle.SetToggle  (speed == TimeController.Speed.Normal);
        NormalToggle.SetToggle  (speed == TimeController.Speed.Normal);
        FastToggle.SetToggle    (speed == TimeController.Speed.Fast);
        FasterToggle.SetToggle  (speed == TimeController.Speed.Faster);
        FastestToggle.SetToggle (speed == TimeController.Speed.Fastest);
    }
}
