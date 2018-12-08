
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Text))]
public class TimeView : MonoBehaviour
{
    protected Text TimeText;

	private void Start()
	{
	    TimeText =  GetComponent<Text>();

	    TimeController.Instance.OnTimeScaleChanged += OnTimeScaleChanged;
	}

    protected void OnTimeScaleChanged(bool isPaused, TimeController.Speed speed)
    {
        throw new System.NotImplementedException();
    }

    private void Update()
	{
	    TimeText.text = TimeController.Instance.CurrentTime.ToString();
	}
}
