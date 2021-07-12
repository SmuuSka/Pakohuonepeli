using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public ParticleSystem explosion;
    public AudioSource mäjähys;

    void Start()
    {
        explosion = GameObject.Find("/Explosion/ExplosionEffect").GetComponent<ParticleSystem>();
        mäjähys = GameObject.Find("Explosion").GetComponent<AudioSource>();
    }
}
