using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerController: MonoBehaviour
{
    public bool grounded;
    public bool canplace;
    public float timer = -5f;
    public float movementForce = 7.5f;
    public float maxspeed;
    public int music;
    public TextMeshProUGUI wintext;
    public Text timertext;

    public GameObject emergencymode;

    public Camera camera;

    private Rigidbody rb;

    public static playerController Instance;

    public soundManager sound;

    public ParticleSystem death;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        grounded = true;
        canplace = true;
        rb = GetComponent<Rigidbody>();

        FindObjectOfType<soundManager>().Play("music(1)");
        music = 1;
        timer = -5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ground"))
        {
            canplace = true;
            grounded = true;
            FindObjectOfType<soundManager>().Play("land");
        }
        if (other.CompareTag("ghostplatform"))
        {
            grounded = true;
            FindObjectOfType<soundManager>().Play("land");
        }
        if (other.CompareTag("key"))
        {
            doorScript.Instance.keynum++;
            FindObjectOfType<soundManager>().Play("key");
            Destroy(other.gameObject);
        }
        if (other.CompareTag("killplat"))
        {
            wintext.text = "You Died! Game Over";
            FindObjectOfType<soundManager>().Play("death");
            death.transform.position = gameObject.transform.position;
            death.Play();
            gameObject.SetActive(false);
        }
        if (other.CompareTag("goal"))
        {
            wintext.text = "You Escaped the Facility.";
            gameObject.SetActive(false);
        }
        if (other.CompareTag("changemusic"))
        {
            FindObjectOfType<soundManager>().Stop("music(1)");
            FindObjectOfType<soundManager>().Play("music(2)");
            FindObjectOfType<soundManager>().Play("explode");
            music = 2;
            emergencymode.SetActive(true);
            timer = 150f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("ground"))
        {
            canplace = false;
            grounded = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        float xmovement = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(xmovement, 0, 0);
        rb.velocity = new Vector3(xmovement * movementForce, rb.velocity.y, rb.velocity.z);

        if (Input.GetKeyDown("space") && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 12.5f, rb.velocity.z);
            canplace = false;
            grounded = false;
            FindObjectOfType<soundManager>().Play("jump");
        }

        if (rb.velocity.x > 7.5f)
        {
            rb.velocity = new Vector3(7.5f, rb.velocity.y, rb.velocity.z);
        }
        if (rb.velocity.x < -7.5f)
        {
            rb.velocity = new Vector3(-7.5f, rb.velocity.y, rb.velocity.z);
        }
        if (timer <= 0 && timer >= -3)
        {
            timer = 0;
        }
        if (timer == 0)
        {
            wintext.text = "Times up. Game Over!";
            FindObjectOfType<soundManager>().Play("death");
            death.transform.position = gameObject.transform.position;
            death.Play();
            gameObject.SetActive(false);
            timertext.text = "0.00";
        }
        var result = (Mathf.Round(timer * 100)) / 100.0;
        timer -= Time.deltaTime;
        timertext.text = result.ToString();

    }
}
