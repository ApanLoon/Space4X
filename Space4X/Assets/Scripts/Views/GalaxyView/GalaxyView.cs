using Space4X.Controllers;
using Space4X.Simulation;
using UnityEngine;

namespace Space4X.Views.GalaxyView
{
    public class GalaxyView : MonoBehaviour
    {
        [SerializeField] protected Camera Camera;
        [SerializeField] protected Material SkyboxMaterial;
        [SerializeField] protected GameObject StarSystemPrefab; //TODO: Get this some other way

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

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    StarSystemView systemView = hit.collider.gameObject.GetComponentInParent<StarSystemView>();
                    if (systemView != null)
                    {
                        SelectionController.Instance.Select(systemView.System);
                        MainViewController.Instance.ShowSystemView();
                    }
                }
            }
        }

        protected void InstantiateStarSystemPrefabs()
        {
            Galaxy galaxy = GameController.Instance.CurrentGalaxy;

            foreach (StarSystem system in galaxy.StarSystems)
            {
                GameObject go = Instantiate(StarSystemPrefab, system.Position, Quaternion.identity, StarSystems);
                StarSystemView view = go.GetComponent<StarSystemView>();
                go.name = "StarSystem(" + system.Name + ")";
                view.System = system;
                view.NameText.text = system.Name;
            }
        }
    }
}
