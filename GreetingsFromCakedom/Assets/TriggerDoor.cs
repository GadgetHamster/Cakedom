using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
      public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
    //  anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
      private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == ("Player")) {
//        Debug.Log("WOOOOOOOOOOOOOOOOOOORK!!!!!!!!!!!!!!!!!");
        anim.SetTrigger("PlayerOpen");
        }
      }

      private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == ("Player")) {
        Debug.Log("WOOOOOOOOOOOOOOOOOOORK!!!!!!!!!!!!!!!!!");
        anim.SetTrigger("PlayerClose");
        }
      }
}
