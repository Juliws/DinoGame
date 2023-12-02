using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    
    public float scrollspeed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * scrollspeed * Time.deltaTime);
    }
}

