using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class menumusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<soundManager>().Play("music(1)");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
