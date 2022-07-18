using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrelBehavior : MonoBehaviour
{
    public float blastRadius = 5f;
    public GameObject barrel;
    public GameObject explodeParticle;
    public AudioClip explodeSound;

    private void Awake()
    {
        barrel.SetActive(true);
    }
    void Explode() // Exploding mechanism
    {
        barrel.SetActive(false);
        Instantiate(explodeParticle, this.transform.position, this.transform.rotation);
        AudioSource.PlayClipAtPoint(explodeSound, this.transform.position);

        Collider[] breakables = Physics.OverlapSphere(this.transform.position, blastRadius);
        
        foreach (Collider breaks in breakables)
        {
            if (breaks.GetComponent<BreakableBehaviour>() != null)
            {
                breaks.GetComponent<BreakableBehaviour>().Collapse();
            }
        }
    }
    private void OnCollisionEnter(Collision collision) //If collide with breakable stuff
    {
        if (collision.gameObject.tag == "Breakable")
        {
            Explode();
        }
    }
    private void OnDrawGizmos() // Blast radius visualize
    {
        Gizmos.DrawWireSphere(this.transform.position, blastRadius);
    }
}
