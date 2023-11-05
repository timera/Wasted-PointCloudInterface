using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class SimpleProceduralMesh : MonoBehaviour {

	List<Vector3> Points = new List<Vector3>();
	List<int> triangleArray = new List<int>();
	Mesh _Mesh;

	public ForensicsController controller;
	void OnEnable()
	{
		_Mesh = new Mesh
		{
			name = "Procedural Mesh"
		};

		GetComponent<MeshFilter>().mesh = _Mesh;
	}

	public void AddPoint(Vector3 newPoint)
    {
		Points.Add(newPoint);
		if (Points.Count < 4)
			return;
		_Mesh.vertices = new Vector3[] { Points[0], Points[1], Points[2], Points[2], Points[3], Points[0] };

		for(int i = 0; i < 6; i ++)
        {
			triangleArray.Add(i);
        }
		_Mesh.triangles = new int[] { 0, 1, 2, 3, 4, 5 };

		Vector3[] vectorArray = new Vector3[] { Vector3.back, Vector3.back, Vector3.back, Vector3.up, Vector3.up, Vector3.up};
		
		_Mesh.normals = vectorArray;
		controller.Area(_Mesh.vertices);
	}

	
}

