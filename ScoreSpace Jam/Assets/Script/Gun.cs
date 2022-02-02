using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletPos;
    bool isShootCD = true;
    AudioSource shootSfx;

    public ParticleSystem smoke;
    // Start is called before the first frame update
    void Start()
    {
        shootSfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if(Input.GetKey(KeyCode.Mouse0) && isShootCD == true) {
        StartCoroutine(shootingCD());
        print("Shooting");
        isShootCD = false;
        
        }
    }


    IEnumerator shootingCD() {
        if(Input.GetKey(KeyCode.Mouse0) && isShootCD == true) {
            smoke.Play();
            //anim recoil
            transform.position += -transform.right * Time.deltaTime * 20;
            shootSfx.Play();
            GameObject clone = Instantiate(bullet, bulletPos.transform.position, gameObject.transform.rotation);
            Rigidbody2D crb = clone.GetComponent<Rigidbody2D>();
            crb.AddForce(transform.right * PlayerPrefs.GetFloat("bulletSpeed"), ForceMode2D.Impulse);
            crb.velocity = Vector2.ClampMagnitude(crb.velocity, PlayerPrefs.GetFloat("bulletSpeed"));
            Destroy(clone, 10);
            //reset
            yield return new WaitForSeconds(0.1f);
            transform.position = new Vector3(0,0,0);
            yield return new WaitForSeconds(PlayerPrefs.GetFloat("fireRate"));
            isShootCD = true;
        }
}

    void recoilAnim() {
        transform.position += transform.right * Time.deltaTime * 10;
    }
}

