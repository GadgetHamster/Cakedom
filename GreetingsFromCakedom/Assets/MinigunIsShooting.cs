using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunIsShooting : MonoBehaviour
{

  Animator anim;
    // Start is called before the first frame update
    void Start()
    {
      anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetMouseButton(0)) {
        anim.SetBool("Shooting", true);
    } else {
      anim.SetBool("Shooting", false);
    }
}
}
