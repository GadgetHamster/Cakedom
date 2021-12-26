using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSceneLoad : MonoBehaviour
{
  public GameObject gameobject;
    // Start is called before the first frame update
    void Awake()
    {
      gameObject.SendMessage("SceneLoaded", SendMessageOptions.DontRequireReceiver);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
