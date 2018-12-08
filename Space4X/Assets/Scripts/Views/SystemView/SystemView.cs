using System.Collections.Generic;
using System.Linq;
using Space4X.Controllers;
using Space4X.Simulation;
using UnityEngine;

namespace Space4X.Views.SystemView
{
    public class SystemView : MonoBehaviour
    {
        [SerializeField] public Material DummySkybox;
        [SerializeField] protected GameObject BodyPrefab;
        [SerializeField] protected Transform BodyContainer;

        public StarSystem System { get; protected set; }

        /// <summary>
        /// Keeps a skybox for each system, each generated the first time saystem
        /// view is shown for a particular star system. The texxtures for the sky
        /// box are generated based on the current galaxy and the position of the
        /// star system.
        /// </summary>
        protected Dictionary<StarSystem, Material> Skyboxes = new Dictionary<StarSystem, Material>();

        private void OnEnable()
        {
            System = SelectionController.Instance.SelectedStarSystems.FirstOrDefault();
            if (System == null)
            {
                Debug.LogError("Enabled SystemView with no system selected!");
                return;
            }

            if (!Skyboxes.ContainsKey(System))
            {
                //TODO: Generate textures for skybox material
                Debug.Log("TODO: Generate skybox material for " + System.Name);
                //TODO: Store skybox material for this system
                Skyboxes.Add(System, DummySkybox);
            }

            RenderSettings.skybox = Skyboxes[System];

            DestroyBodies();

            foreach (CelestialBody body in System.Bodies)
            {
                InstantiateBodies(body, BodyContainer);
            }
        }

        protected void DestroyBodies()
        {
            while (BodyContainer.childCount > 0)
            {
                Transform child = BodyContainer.GetChild(0);
                child.SetParent(null);
                GameObject.Destroy(child.gameObject);
            }
        }

        protected void InstantiateBodies(CelestialBody body, Transform container)
        {
            GameObject go = Instantiate(BodyPrefab, body.Position, Quaternion.identity, container);
            BodyView view = go.GetComponent<BodyView>();
            go.name = body.Name;
            view.Body = body;
            view.NameText.text = body.Name;

            foreach (CelestialBody child in body.Orbiters)
            {
                InstantiateBodies(child, go.transform);
            }
        }


        private void Update()
        {
            for (int i = 0; i < BodyContainer.childCount; i++)
            {
                UpdateBodies(BodyContainer.GetChild(i));
            }
        }

        protected void UpdateBodies(Transform t)
        {
            BodyView view = t.GetComponent<BodyView>();
            if (view == null)
            {
                return;
            }

            t.localPosition = view.Body.Position;

            for (int i = 0; i < t.childCount; i++)
            {
                UpdateBodies(t.GetChild(i));
            }
        }

    }
}
