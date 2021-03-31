using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public int keynum = 0;
    public GameObject door1;

    public static doorScript Instance;

    private void Start()
    {
        Instance = this;
    }
    void Update()
    {
        if (keynum == 1)
        {
            Destroy(door1);
        }
    }
}
