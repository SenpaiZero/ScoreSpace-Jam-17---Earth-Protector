using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class darkMatter : MonoBehaviour
{
    Transform darkMatterObj;
    Vector2 velocity;
    Vector3 uiPos;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        darkMatterObj = GameObject.FindGameObjectWithTag("coin").GetComponent<Transform>();
        uiPos = Camera.main.ScreenToWorldPoint(darkMatterObj.position);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, Camera.main.ScreenToWorldPoint(new Vector3(darkMatterObj.position.x - 100,
                                                                                                                        darkMatterObj.position.y + 25,
                                                                                                                        darkMatterObj.position.z)));
        
        if(distance > 10.05) {
        transform.position = Vector2.SmoothDamp(transform.position, Camera.main.ScreenToWorldPoint(new Vector3(darkMatterObj.position.x - 100,
                                                                                                                        darkMatterObj.position.y + 25,
                                                                                                                        darkMatterObj.position.z)), ref velocity, 1);
        }
        else {
            PlayerPrefs.SetInt("darkMatter", PlayerPrefs.GetInt("darkMatter") + 1);
            PlayerPrefs.Save();
            Destroy(gameObject);
        }
    }
}
