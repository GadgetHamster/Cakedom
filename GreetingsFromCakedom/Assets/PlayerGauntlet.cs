using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGauntlet : MonoBehaviour
{
 public Animator anim;
 public Animator blackAnim;
 public bool GauntletIsExtended;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.G)) {
        if(GauntletIsExtended == true) {
          anim.SetTrigger("MoveGloveOffscreen");
          blackAnim.SetTrigger("FadeFromBlack");
          GauntletIsExtended = false;
        } else {
          anim.SetTrigger("MoveGloveOnscreen");
          blackAnim.SetTrigger("FadeToBlack");
          GauntletIsExtended = true;
        }

      }

    }
}
