using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variableStorage : MonoBehaviour
{
  public float x = 0;

  Vector3 camPos;

    // Start is called before the first frame update
    void Start()
    {
    camPos = transform.position;
    x = camPos.x;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
