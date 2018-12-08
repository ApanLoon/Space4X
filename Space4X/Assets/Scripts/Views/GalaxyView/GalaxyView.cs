using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyView : MonoBehaviour
{

    public Material SkyboxMaterial;
    public GameObject StarSystemPrefab; //TODO: Get this some other way

    protected Transform StarSystems;

    private void OnEnable()
    {
        StarSystems = transform.Find("StarSystems").transform;

        RenderSettings.skybox = SkyboxMaterial;

        if (StarSystems.childCount == 0)
        {
            InstantiateStarSystemPrefabs();
        }
    }

    protected void InstantiateStarSystemPrefabs()
    {
        Galaxy galaxy = GameController.Instance.CurrentGalaxy;

        foreach (StarSystem system in galaxy.StarSystems)
        {
            GameObject go = Instantiate(StarSystemPrefab, system.Position, Quaternion.identity, StarSystems);
            GvStarSystemView view = go.GetComponent<GvStarSystemView>();
            go.name = "StarSystem(" + system.Name + ")";
            view.NameText.text = system.Name;
        }
    }
}
