using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    public int speed = 8;
    public int multiplier = 100;  
 
    public void FixedUpdate()
    {
        transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y + speed * multiplier * Time.deltaTime, transform.rotation.z));
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other)
        {
            GameObject.Find("/Explosion/ExplosionEffect").GetComponent<ParticleSystem>().Play();
            GameObject.Find("Explosion").GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
            GameObject.Find("/Ventti (1)/Dropzone").GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
