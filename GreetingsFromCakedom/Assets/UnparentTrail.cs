using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnparentTrail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Unparent()
    {
      this.transform.parent = null;
    }


}
