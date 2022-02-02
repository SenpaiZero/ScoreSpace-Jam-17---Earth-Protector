using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldParent : MonoBehaviour
{
    public GameObject pivot;
    public float speed = 90f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)) {
            transform.RotateAround(pivot.transform.position, Vector3.forward, speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.RotateAround(pivot.transform.position, Vector3.forward, -speed * Time.deltaTime);    
        }
    }
}
