using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public GameObject pivot;
    public float speed;
    public Vector3 scaling = new Vector3(3, 0.3f, 1);
    public GameObject hitPart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKey(KeyCode.A)) {
        //     transform.RotateAround(pivot.transform.position, Vector3.forward, speed * Time.deltaTime);
        // }
        // if(Input.GetKey(KeyCode.D)){
        //     transform.RotateAround(pivot.transform.position, Vector3.forward, -speed * Time.deltaTime);    
        // }

    }

    public void changeScale(Vector3 scaling, float increase) {
        if(transform.localScale.x <= 4) {
            scaling = new Vector3(transform.localScale.x + increase, transform.localScale.y, transform.localScale.z);
            transform.localScale = scaling;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<AsteroidScript>().dead();
        }
        GameObject clone = Instantiate(hitPart, other.transform.position, Quaternion.identity);
        Destroy(clone, 5);
    }
    
}
