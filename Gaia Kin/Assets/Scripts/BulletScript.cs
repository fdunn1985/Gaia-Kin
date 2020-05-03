using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D bulletPrefab;
    public float attackSpeed = 0.5f;
    public float coolDown;
    public float projectileSpeed = 500;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && Time.time > coolDown) {
            Shoot();
        }
    }

    void Shoot() {
        Rigidbody2D bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as Rigidbody2D;
        if (transform.localScale.x > 0) {
            bullet.velocity = transform.right * projectileSpeed;
        }
        else {
            Vector3 temp = bullet.transform.localScale;
            temp.x = -Mathf.Abs(temp.x);
            bullet.transform.localScale = temp;
            bullet.velocity = -transform.right * projectileSpeed;
        }

        coolDown = Time.time + attackSpeed;
    }
}
