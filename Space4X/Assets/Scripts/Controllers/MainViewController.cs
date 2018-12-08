using System;
using UnityEngine;

public class MainViewController : MonoBehaviour
{
    public static MainViewController Instance;

    public GameObject GalaxyViewGO;

    public GameObject SystemViewGO;

    public event Action<MainView> OnMainViewChange;

    public enum MainView
    {
        Galaxy,
        System
    }

    public MainView CurrentMainView { get; protected set; }


    public void ShowGalaxyView()
    {
        SystemViewGO.SetActive(false);
        GalaxyViewGO.SetActive(true);
        CurrentMainView = MainView.Galaxy;
        RaiseOnMainViewChange();
    }

    public void ShowSystemView()
    {
        GalaxyViewGO.SetActive(false);
        SystemViewGO.SetActive(true);
        CurrentMainView = MainView.System;
        RaiseOnMainViewChange();
    }

    protected void RaiseOnMainViewChange()
    {
        if (OnMainViewChange != null)
        {
            OnMainViewChange(CurrentMainView);
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
            Debug.LogError("Multiple MainViewControllers in scene!");
            gameObject.SetActive(false);
            return;
        }
    }
}
