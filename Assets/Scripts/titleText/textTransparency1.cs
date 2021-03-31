using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textTransparency1 : MonoBehaviour
{
    public float bValue = -1.5f;

    public CanvasGroup middle;


    private void Start()
    {
    }
    private void FixedUpdate()
    {
        middle = GetComponentInChildren<CanvasGroup>();
        if (bValue < 1)
        {
            bValue += Time.deltaTime / 2f;

            middle.alpha = bValue;
        }
    }
}
