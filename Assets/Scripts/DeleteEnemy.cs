using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PoolObject))]

public class DeleteEnemy : MonoBehaviour
{
    PoolObject poolObject;
    [SerializeField] GameObject instObject;
    void Start()
    {
        poolObject = GetComponent<PoolObject>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bonfire")
        {
            poolObject.ReturnToPool();
            //Destroy(gameObject);
        }
        if (other.gameObject.tag == "Block")
        {
            poolObject.ReturnToPool();
            //Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(instObject, gameObject.transform.position, Quaternion.identity);
        }
    }
}
