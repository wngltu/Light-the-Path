using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuCursor : MonoBehaviour
{
    public ParticleSystem particle;
    public Camera camera;

    void Start()
    {
    }
    void Update()
    {
        clickfx();
    }

    void clickfx()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                this.transform.position = hit.point;
                particle.Play();
            }
        }
    }
}


