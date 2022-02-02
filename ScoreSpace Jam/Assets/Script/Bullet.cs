using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitPart;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag != "Earth") {
            if(other.gameObject.tag == "Enemy") {
                other.GetComponent<AsteroidScript>().dead();
                Destroy(gameObject);
                GameObject clone = Instantiate(hitPart, transform.position, Quaternion.identity);
                Destroy(clone, 5);
            }
            else {
                Destroy(gameObject);
            }
                Animation camShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animation>();
                camShake.Play();
        }
    }
}
