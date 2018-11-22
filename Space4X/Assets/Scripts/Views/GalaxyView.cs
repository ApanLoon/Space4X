using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyView : MonoBehaviour
{

    public Material SkyboxMaterial;

    private void OnEnable()
    {
        RenderSettings.skybox = SkyboxMaterial;
    }
}
