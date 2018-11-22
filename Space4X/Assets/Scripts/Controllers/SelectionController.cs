using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    public static SelectionController Instance;

    public List<StarSystem> SelectedStarSystems
    {
        get { return selecteStarSystems;}
    }
    protected List<StarSystem> selecteStarSystems = new List<StarSystem>();

    public void Select(StarSystem system, bool add = false)
    {
        if (!add)
        {
            SelectedStarSystems.Clear();
        }

        if (!SelectedStarSystems.Contains(system))
        {
            SelectedStarSystems.Add(system);
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
            Debug.LogError("Multiple SelectionControllers in scene!");
            gameObject.SetActive(false);
            return;
        }
    }
}
