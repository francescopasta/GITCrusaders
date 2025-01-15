using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PointIncrementation : MonoBehaviour
{
    public Detection detection;
    
    private void Start()
    {
        if (transform == detection.points[0])
        {
            detection.startPoint = this.transform;
        }
        else if (transform == detection.points[detection.points.Count - 1]) 
        {
            detection.endPoint = this.transform;  
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (detection.startPoint == this.transform && detection.movingToStartPoint)
        {
            detection.movingToStartPoint = false;
        }
        if (detection.endPoint == this.transform)
        {
            detection.movingToStartPoint = true;
        }
        if (!detection.movingToStartPoint)
        {
            detection.i++;
        }
        else
        {
            detection.i--;  
        }
    }
}
