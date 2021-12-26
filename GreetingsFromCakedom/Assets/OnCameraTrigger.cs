using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCameraTrigger : MonoBehaviour
{
  public GameObject CameraTarget;
    // Start is called before the first frame update
    void Start()
    {
      Debug.Log("Testing Testing");
    }

    void Awake() {
      CameraTarget = GameObject.Find("PlayerCameraTarget");
    }

    // Update is called once per frame
    void Update()
    {
      CameraTarget = GameObject.Find("PlayerCameraTarget");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Before");
      if (other.gameObject.tag == ("CameraChange")) {
        float X = other.gameObject.GetComponent<variableStorage>().x;
        Debug.Log("After");
        Vector3 cameraPos = CameraTarget.transform.position;
        cameraPos.x = X;
        CameraTarget.transform.position = cameraPos;

      }

   }
}
