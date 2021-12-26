using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigDoor : MonoBehaviour
{
  private bool isTouching = false;
  public int scene;
  public Vector3 startPos = new Vector3(0f, 2.5f, -1f);

  public Animator anim;
  private int curScene;

    // Start is called before the first frame update
    void Start()
    {
    //  anim = gameObject.GetComponent<Animator>();
      anim.SetTrigger("FadeFromBlack");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
      scene = SceneManager.GetActiveScene().buildIndex;

      if(isTouching == true && Input.GetKey(KeyCode.W) && scene == 1){
  //      anim.SetTrigger("FadeToBlack");
        curScene = 2;
        StartCoroutine(Transition());

      //  SceneManager.LoadScene(2);
      //  this.transform.position = startPos;
      }
      if(isTouching == true && Input.GetKey(KeyCode.W) && scene == 0){
  //      anim.SetTrigger("FadeToBlack");
        curScene = 1;
        StartCoroutine(Transition());

    //    SceneManager.LoadScene(1);
    //    this.transform.position = startPos;
      }
      if(isTouching == true && Input.GetKey(KeyCode.W) && scene == 2){
    //    anim.SetTrigger("FadeToBlack");
        curScene = 1;
        StartCoroutine(Transition());

    //    SceneManager.LoadScene(1);
    //    this.transform.position = startPos;
      }
    }

    void OnTriggerEnter2D(Collider2D col)
  {
      if (col.gameObject.tag == ("BigDoor")) {
        isTouching = true;
      }
  }
  void OnTriggerExit2D(Collider2D col)
{
    if (col.gameObject.tag == ("BigDoor")) {
      isTouching = false;    }
    }


    public IEnumerator Transition()
    {

      anim.SetTrigger("FadeToBlack");
      yield return new WaitForSeconds(1);
      this.transform.position = startPos;
      yield return new WaitForSeconds(1);
      SceneManager.LoadScene(curScene);
      anim.SetTrigger("FadeFromBlack");


    }

    public void SceneLoaded() {
      anim.SetTrigger("FadeFromBlack");
    }
}
