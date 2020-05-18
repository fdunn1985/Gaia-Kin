using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D bulletPrefab;
    public float attackSpeed = 0.5f;
    public float coolDown;
    public float projectileSpeed = 500;
    private Rigidbody2D[] bulletArr;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        bulletArr = new Rigidbody2D[20];
        for (int i=0; i < bulletArr.Length; i++) {
            bulletArr[i] = Instantiate(bulletPrefab, transform.position, transform.rotation) as Rigidbody2D;
            bulletArr[i].GetComponent<Renderer>().enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && Time.time > coolDown) {
            Shoot();
        }
    }

    void Shoot() {
        bulletArr[counter].GetComponent<Renderer>().enabled = true;
        //print("Set " + counter + " to visible");

        Vector3 tempPos = transform.position;
        if (transform.localScale.x > 0) {
            Vector3 temp = bulletArr[counter].transform.localScale;
            temp.x = Mathf.Abs(temp.x);
            bulletArr[counter].transform.localScale = temp;

            tempPos.x = tempPos.x + GetComponent<SpriteRenderer>().bounds.size.x;
            bulletArr[counter].transform.position = tempPos;
            bulletArr[counter].velocity = transform.right * projectileSpeed;
        }
        else {
            tempPos.x = tempPos.x - GetComponent<SpriteRenderer>().bounds.size.x;
            bulletArr[counter].transform.position = tempPos;

            Vector3 temp = bulletArr[counter].transform.localScale;
            temp.x = -Mathf.Abs(temp.x);
            bulletArr[counter].transform.localScale = temp;
            bulletArr[counter].velocity = -transform.right * projectileSpeed;
        }

        counter++;
        if (counter >= bulletArr.Length) {
            counter = 0;
            //print("Setting Counter to 0");
        }
        coolDown = Time.time + attackSpeed;
    }
}
