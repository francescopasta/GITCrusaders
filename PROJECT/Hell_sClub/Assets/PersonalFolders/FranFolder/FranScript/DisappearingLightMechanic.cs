using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingLightMechanic : MonoBehaviour
{
    //private Mesh originalMesh;
    //private Vector3[] originalVertices;

    //void Start()
    //{
    //    originalMesh = GetComponent<MeshFilter>().mesh;
    //    originalVertices = originalMesh.vertices;
    //}

    //void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Cover"))
    //    {
    //        Vector3 contactPoint = other.ClosestPoint(transform.position);
    //        ClipMesh(contactPoint);
    //    }
    //}

    //void ClipMesh(Vector3 contactPoint)
    //{
    //    Vector3[] modifiedVertices = originalVertices.Clone() as Vector3[];

    //    for (int i = 0; i < modifiedVertices.Length; i++)
    //    {
    //        if (Vector3.Distance(transform.TransformPoint(modifiedVertices[i]), contactPoint) < 1f) // Adjust threshold
    //        {
    //            modifiedVertices[i] = new Vector3(modifiedVertices[i].x, 0, modifiedVertices[i].z);
    //        }
    //    }

    //    originalMesh.vertices = modifiedVertices;
    //    originalMesh.RecalculateNormals();
    //}
}
