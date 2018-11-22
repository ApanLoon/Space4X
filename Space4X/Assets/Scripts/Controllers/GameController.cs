
using UnityEngine;

public class GameController : MonoBehaviour
{

    protected Galaxy CurrentGalaxy;

    public void NewGame()
    {
        CurrentGalaxy = new Galaxy(GalaxyType.Spiral, GalaxySize.Small);
        SelectionController.Instance.Select(CurrentGalaxy.StarSystems[0]);
        MainViewController.Instance.ShowSystemView();
    }

    private void Start()
	{
	    NewGame();
	}
}
