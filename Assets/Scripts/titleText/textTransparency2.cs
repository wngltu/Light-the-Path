using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textTransparency2 : MonoBehaviour
{
    public float cValue = -2;

    public CanvasGroup right;


    private void Start()
    {
    }
    private void FixedUpdate()
    {
        right = GetComponent<CanvasGroup>();
        if (cValue < 1)
        {
            cValue += Time.deltaTime / 2f;

            right.alpha = cValue;
        }
    }
}
