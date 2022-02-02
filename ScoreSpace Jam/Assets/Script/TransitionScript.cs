using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScript : MonoBehaviour
{
    public GameObject transitionDone;
    public GameObject transitionExit;
    // Start is called before the first frame update
    void Start()
    {
        GameObject clone = Instantiate(transitionDone, new Vector3(0,0,0), Quaternion.identity);
        Destroy(clone, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void transitionSceneDone() {
        GameObject clone = Instantiate(transitionDone, new Vector3(0,0,0), Quaternion.identity);
        Destroy(clone, 5);
    }
    public void transitionSceneExit() {
        GameObject clone = Instantiate(transitionExit, new Vector3(0,0,0), Quaternion.identity);
        Destroy(clone, 5);
    }
    
}
