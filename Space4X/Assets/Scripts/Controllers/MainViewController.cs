using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainViewController : MonoBehaviour
{
    public static MainViewController Instance;

    public GameObject GalaxyViewGO;

    public GameObject SystemViewGO;

    public void ShowGalaxyView()
    {
        SystemViewGO.SetActive(false);
        GalaxyViewGO.SetActive(true);
    }

    public void ShowSystemView()
    {
        GalaxyViewGO.SetActive(false);
        SystemViewGO.SetActive(true);
    }

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.LogError("Multiple MainViewControllers in scene!");
            gameObject.SetActive(false);
            return;
        }
    }
}
