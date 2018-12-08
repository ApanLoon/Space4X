
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public Galaxy CurrentGalaxy { get; private set; }

    public void NewGame()
    {
        CurrentGalaxy = new Galaxy(GalaxyType.Spiral, GalaxySize.Small);

        // Select home system and go into system view:
        SelectionController.Instance.Select(CurrentGalaxy.StarSystems[0]);
        //MainViewController.Instance.ShowSystemView();
        MainViewController.Instance.ShowGalaxyView();

    }

    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.LogError("Multiple GameControllers in scene!");
            gameObject.SetActive(false);
            return;
        }
    }
    private void Start()
	{
	    NewGame();
	}
}
