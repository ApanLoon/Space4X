
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SystemView : MonoBehaviour
{
    public Material DummySkybox;

    /// <summary>
    /// Keeps a skybox for each system, each generated the first time saystem
    /// view is shown for a particular star system. The texxtures for the sky
    /// box are generated based on the current galaxy and the position of the
    /// star system.
    /// </summary>
    protected Dictionary<StarSystem, Material> Skyboxes = new Dictionary<StarSystem, Material>();

    private void OnEnable()
    {
        StarSystem system = SelectionController.Instance.SelectedStarSystems.FirstOrDefault();
        if (system == null)
        {
            Debug.LogError("Enabled SystemView with no system selected!");
            return;
        }

        if (!Skyboxes.ContainsKey(system))
        {
            //TODO: Generate textures for skybox material
            Debug.Log("TODO: Generate skybox material for " + system.Name);
            //TODO: Store skybox material for this system
            Skyboxes.Add(system, DummySkybox);
        }

        RenderSettings.skybox = Skyboxes[system];
    }
}
