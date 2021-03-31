using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textTransparency : MonoBehaviour
{
    public float aValue = -1;

    public CanvasGroup left;


    private void Start()
    {
    }
    private void FixedUpdate()
    {
        left = GetComponent<CanvasGroup>();
        if (aValue < 1)
        {
            aValue += Time.deltaTime/2f;

            left.alpha = aValue;
        }
    }
}
