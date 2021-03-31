using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostplatClicker : MonoBehaviour
{
    public Camera camera;
    public ParticleSystem appear;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerController.Instance.canplace)
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("ghostplatform"))
                {
                    hit.transform.gameObject.SendMessage("toggle");
                    appear.transform.position = hit.transform.position;
                    appear.Play();
                }
            }
        }
    }
}
