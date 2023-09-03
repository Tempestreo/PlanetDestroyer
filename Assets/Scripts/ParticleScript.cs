using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    ParticleSystem particle;
    [System.Obsolete]
    void Start()
    {
        //launch particle system and change its properties by size
        particle = this.GetComponent<ParticleSystem>();
        particle.transform.localScale = GetComponentInParent<MeteoriteScript>().transform.localScale;
    }
    internal void UpdateSize()
    {
        particle = this.GetComponent<ParticleSystem>();
        particle.transform.localScale = GetComponentInParent<MeteoriteScript>().transform.localScale;
    }
}
