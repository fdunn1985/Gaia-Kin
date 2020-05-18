using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy") {
            
            Animator m_Animator = col.gameObject.GetComponent<Animator>();
            
            m_Animator.SetBool("IsDead", true);
            

            gameObject.GetComponent<Renderer>().enabled = false;

            //TODO: Figure out how to hide (re-use later) enemy after it dies


            //WaitForSeconds(m_Animator.GetCurrentAnimatorStateInfo(0).length);

            //print("BEFORE Wait");
            ////WaitForAnim(m_Animator, col.gameObject);
            //Invoke("DisableEnemy", 2.0f);
            //print("AFTER Wait");
            Destroy(col.gameObject, 0.4f);

            //if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Enemy_1_Death")) {
            //    print("disable enemy");

            //col.gameObject.GetComponent<Renderer>().enabled = false;
            //}

        }
    }

    void DisableEnemy(GameObject obj) {
        obj.GetComponent<Renderer>().enabled = false;
    }

    IEnumerator WaitForAnim(Animator anim, GameObject obj) {
        print("Time to wait: " + anim.GetCurrentAnimatorStateInfo(0).length);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        obj.GetComponent<Renderer>().enabled = false;


        //while ((anim.GetCurrentAnimatorStateInfo(0).normalizedTime) % 1 < 0.99f) {
        //    yield return null;
        //}

        //print("disable enemy");

        //obj.GetComponent<Renderer>().enabled = false;
    }
}
