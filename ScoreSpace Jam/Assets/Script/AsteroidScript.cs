using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    float speed;
    public GameObject darkMatterObj;
    Transform target;
    Rigidbody2D rb;
    int rand;
    int rand2;
    float hp = 1;
    // Start is called before the first frame update
    void Start()
    {
        speed = PlayerPrefs.GetFloat("enemySpeed");
        rand2 = Random.Range(0, 2);
        rb = gameObject.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Earth").GetComponent<Transform>();

        if(rand2 == 0) {
            rand = Random.Range(15, 40);
        }
        else {
            rand = Random.Range(-15, -40);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back * Time.deltaTime * rand, Space.World);
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);

        
        
    }

    public void enemyDamageTaken(float dmg) {

    }

    public void dead() {
        PlayerPrefs.SetInt("currentKilled", PlayerPrefs.GetInt("currentKilled") + 1);
        PlayerPrefs.SetInt("comboCounter", PlayerPrefs.GetInt("comboCounter") + 1);
        if(PlayerPrefs.GetInt("comboCounter") > 0) {
            PlayerPrefs.SetInt("currentScore", PlayerPrefs.GetInt("currentScore") + (1 * PlayerPrefs.GetInt("comboCounter")));
        }
        else {
            PlayerPrefs.SetInt("currentScore", PlayerPrefs.GetInt("currentScore") + 1 );
        }
        PlayerPrefs.Save();
        Instantiate(darkMatterObj, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
