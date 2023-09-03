using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    ParticleSystem particle;
    MeteoriteScript scmeteorite;
    void Start()
    {
        scmeteorite = FindObjectOfType<MeteoriteScript>();
        this.transform.localScale *= scmeteorite.gameObject.transform.localScale.x;
    }
}
