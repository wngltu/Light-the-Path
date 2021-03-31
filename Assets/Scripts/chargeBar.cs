using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargeBar : MonoBehaviour
{
    public static chargeBar Instance;
    public Transform chargeParent;
    public Transform chargeIconPrefab;
    private int chargeDisplayed;
    public int chargeValue;
    public ParticleSystem inhale;
    public ParticleSystem exhale;
    public soundManager sound;
    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        if (chargeDisplayed < chargeValue)
        {
            chargeDisplayed = chargeValue;
            gainCharge();
        }
        if (chargeDisplayed > chargeValue)
        {
            chargeDisplayed = chargeValue;
            loseCharge();
        }

    }
    void gainCharge()
    {
        Instantiate(chargeIconPrefab, chargeParent);
        inhale.Play();

        FindObjectOfType<soundManager>().Play("inhale");
    }
    void loseCharge()
    {
        Transform[] spawnedBars = chargeParent.GetComponentsInChildren<Transform>();
        int i = spawnedBars.Length - 1;
        Destroy(spawnedBars[i].gameObject);
        exhale.Play();

        FindObjectOfType<soundManager>().Play("exhale");
    }
}
