﻿
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Text))]
public class TimeView : MonoBehaviour
{
    protected Text TimeText;

	private void Start()
	{
	    TimeText =  GetComponent<Text>();
	}

    private void Update()
	{
	    TimeText.text = TimeController.Instance.CurrentTime.ToString();
	}
}
