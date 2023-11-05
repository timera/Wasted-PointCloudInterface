using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using System;
using TMPro;

public class ForensicsController : MonoBehaviour
{
    public cwmDoubleTapMoveCameraAndGetClick DoubleTapController;

    public GameObject PinToDrop;

    public GameObject PinRoot;

    public GameObject MeshGO;

    public GameObject DroppedMeshGO;

    public GameObject Panel;

    public TMP_Text SQFTText;
    public void ToggleForensicsMode()
    {
        DoubleTapController.ForensicMode = !DoubleTapController.ForensicMode;
        if (!DoubleTapController.ForensicMode)
        {
            if (PinRoot.transform.childCount == 0)
                return;
            for (int i = PinRoot.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(PinRoot.transform.GetChild(i).gameObject);
            }

            if (DroppedMeshGO)
                Destroy(DroppedMeshGO);
            Panel.SetActive(false);
        }
        else
        {
            Panel.SetActive(true);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropPin(Vector3 point)
    {
        Instantiate(PinToDrop, PinRoot.transform);
        PinToDrop.transform.position = point;
        if (DroppedMeshGO == null)
            DroppedMeshGO = Instantiate(MeshGO);
        DroppedMeshGO.transform.position = Vector3.zero;
        DroppedMeshGO.GetComponent<SimpleProceduralMesh>().AddPoint(point);
        DroppedMeshGO.GetComponent<SimpleProceduralMesh>().controller = this;
    }

    public void Area(Vector3[] vertices)
    {
        Vector3 result = Vector3.zero;
        for (int p = vertices.Length - 1, q = 0; q < vertices.Length; p = q++)
        {
            result += Vector3.Cross(vertices[q], vertices[p]);
        }
        result *= 0.5f;
        result *= 10.76f;
        SQFTText.text = "" +  result.magnitude;
    }
}
