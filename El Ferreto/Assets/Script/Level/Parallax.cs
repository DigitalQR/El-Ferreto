using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        renderer.material.mainTextureOffset = new Vector2(Time.time * speed, 0);
    }
}

