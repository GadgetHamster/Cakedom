using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsWalking : MonoBehaviour
{

  Animator anim;
  public Rigidbody2D rb;
  private float pastX = 1;


    void Awake(){
      pastX = this.transform.position.x;
    }
    // Start is called before the first frame update
    void Start()
    {
      anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
      if (pastX != rb.transform.position.x){
        anim.SetTrigger("Walking");
      } else {
        anim.SetTrigger("Standing");
      }
      pastX = rb.transform.position.x;

  /*    //if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) {
      if(rb. < Vector2(0.1f)) {

        anim.SetBool("IsWalking", true);    } else {
      anim.SetBool("IsWalking", false);
    }*/
    }
}
