using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public int damage = 1;
    public float lifeTime = 3.0f;
    public string target = "Player";

    private void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == target)
        {
            Health health = other.GetComponent<Health>();

            if (health != null)
            {
                health.GetHit(damage, transform.root.gameObject);
            }
            Destroy(gameObject);
        }
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
