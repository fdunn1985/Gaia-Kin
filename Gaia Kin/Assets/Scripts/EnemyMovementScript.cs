using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public float cooldown = 0f;
    private float actionWait = 2f;
    private bool isMoving = false;
    private Animator m_Animator;
    private bool isMovingLeft = false;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) {
            Vector3 temp = transform.position;
            Vector3 tempTransform = transform.localScale;
            
            if (isMovingLeft) {
                temp.x -= 0.001f;
                tempTransform.x = -Math.Abs(tempTransform.x);
            } else {
                temp.x += 0.001f;
                tempTransform.x = Math.Abs(tempTransform.x);
            }

            transform.position = temp;
            transform.localScale = tempTransform;
        }

        if (Time.time > cooldown) {
            isMoving = !isMoving;
            m_Animator.SetBool("IsMoving", isMoving);

            if (isMoving) {
                int randNum = UnityEngine.Random.Range(0, 2);
                print("Random move number: " + randNum);
                if (randNum == 0) {
                    isMovingLeft = true;
                } else {
                    isMovingLeft = false;    
                }
            }

            cooldown = Time.time + actionWait;
        }
    }
}
