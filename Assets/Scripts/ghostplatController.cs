using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostplatController : MonoBehaviour
{
    public Material off;
    public Material on;

    public bool solidified;

    public BoxCollider col;
    public BoxCollider col2;

    public static ghostplatController Instance;

    public Camera camera;

    public ParticleSystem inhale;
    public ParticleSystem exhale;

    private void Start()
    {
        Instance = this;
        solidified = false;
    }
    private void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bounceplat"))
        {
            this.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb);
            rb.velocity = new Vector3(0, 20);
        }
    }
    void toggle()
    {
        Invoke("timedToggle", .5f);
    }
    void timedToggle()
    {
        if (solidified == false && chargeBar.Instance.chargeValue > 0) //turn on (solidify platform)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = on;
            col.enabled = true;
            col2.enabled = true;
            chargeBar.Instance.chargeValue = chargeBar.Instance.chargeValue - 1;
            solidified = !solidified;
        }
        else if (solidified == true) //turn off (unsolidify platform)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = off;
            col.enabled = false;
            col2.enabled = false;
            chargeBar.Instance.chargeValue = chargeBar.Instance.chargeValue + 1;
            solidified = !solidified;
        }
    }
}
