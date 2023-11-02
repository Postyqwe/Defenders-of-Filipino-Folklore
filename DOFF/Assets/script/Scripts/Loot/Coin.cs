using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Coin : MonoBehaviour
{
    public int amount = 1;
    public float followSpeed = 5.0f;

    Transform target;
    CoinBar coinBar;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        coinBar = GameObject.FindGameObjectWithTag("CoinCount").GetComponent<CoinBar>();
    }

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;

            float step = followSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Collect()
    {
        coinBar.GetCoin(amount);
        Destroy(gameObject);
    }
}