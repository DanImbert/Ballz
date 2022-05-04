using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowExplosive : MonoBehaviour
{

    public float throwForce = 40f;
    public GameObject explosivePrefab;



    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touchCount < 2 && Input.touches[0].phase == TouchPhase.Began)
        {
            ThrownExplosive();
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider != null)
                {
                    Color newColor =  new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                    hit.collider.GetComponent<MeshRenderer>().material.color = newColor;
                }
            }
            
        }
    }

    void ThrownExplosive()
    {
        GameObject explosive = Instantiate(explosivePrefab, transform.position, transform.rotation);
        Rigidbody rb = explosive.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }

}
