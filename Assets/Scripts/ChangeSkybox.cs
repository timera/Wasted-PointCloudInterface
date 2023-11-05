using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkybox : MonoBehaviour
{
    public Material SkyboxMaterial;
    public GameObject Model;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        RenderSettings.skybox = SkyboxMaterial;
        Model.SetActive(false);
    }
}
