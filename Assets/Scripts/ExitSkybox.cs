using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSkybox : MonoBehaviour
{
    public GameObject Model;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitSkyboxButtonClick()
    {
        RenderSettings.skybox = null;
        Model.SetActive(true);
    }
}
