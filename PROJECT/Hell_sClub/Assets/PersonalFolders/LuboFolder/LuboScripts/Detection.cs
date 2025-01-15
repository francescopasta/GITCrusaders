using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Detection : MonoBehaviour
{
    
    public List<Transform> points = new List<Transform>();
    public float speed = 0.3f;
    public int i = 0;
    Vector3 direction;
    public Transform startPoint;
    public Transform endPoint;
    public bool movingToStartPoint;

    private void FixedUpdate()
    {
        direction = (points[i].position - transform.position).normalized;
            transform.position += direction * speed;
    }

    
}
