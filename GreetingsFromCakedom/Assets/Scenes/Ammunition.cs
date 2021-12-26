using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ammunition : MonoBehaviour
{
  public bool isRegening;
  public int ammo;
  public Slider Ammo;
  public Text text;

  Weapon weapon;
  AutoWeapon autoWeapon;

  WeaponScript weaponScript;

  //public int AmmoConsumption = 1;

  public int CurrentAmmo = 50;
  string strCurrentAmmo;

  public int MaxAmmo = 50;
  string strMaxAmmo;

  private float timer = 10f;
  private float maxTimer;

    // Start is called before the first frame update
    void Start()
    {
      weapon = GetComponent<Weapon>();
      autoWeapon = GetComponent<AutoWeapon>();
      weaponScript = GetComponentInChildren<WeaponScript>();


      maxTimer = timer;
    //  StartCoroutine(RegenBullets());  // CurrentAmmo


    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(CurrentAmmo < 0) {
        CurrentAmmo = 0;
      }



      Ammo.maxValue = MaxAmmo;
      string strCurrentAmmo = CurrentAmmo.ToString();
      string strMaxAmmo = MaxAmmo.ToString();
      Ammo.value = CurrentAmmo;

      text.text = (strCurrentAmmo + "/" + strMaxAmmo);

    }
    void Update() {
      timer--;

  //    if(weapon.shooting == true || autoWeapon.shooting == true) {
  //      timer = maxTimer;
  //    }

      if(weaponScript.shooting == false && CurrentAmmo < MaxAmmo && isRegening == false && timer < 0f) {
      //   || autoWeapon.shooting == false && CurrentAmmo < MaxAmmo && isRegening == false && timer < 0f
        timer = maxTimer;
        //TO DO: START CO ROUTINE WITH DELAY
        StartCoroutine(RegenBullets());  // CurrentAmmo
        isRegening = true;

      } else if(isRegening == true) {
        return;
      } else {
        isRegening = false;
      }
    }
    void RegenAmmo(){
      if(CurrentAmmo != MaxAmmo)
        CurrentAmmo++;
    }

    public IEnumerator RegenBullets() // int CurrentAmmo
    {
      //while(isRegening == true) //weapon.shooting == false && CurrentAmmo < MaxAmmo
    //  {
      Debug.Log("starting timer...");
      yield return new WaitForSeconds(1);
      Debug.Log("ending timer...");
      CurrentAmmo = CurrentAmmo + 1;
      isRegening = false;
  //  } else {
        //StartCoroutine(RegenBullets());  // CurrentAmmo
  //    }
    }

    public bool IsThereEnough() {
      if(weaponScript.AmmoConsumption > CurrentAmmo) {
        return false;
      }
      return true;
    }
    public void Shot() {

      CurrentAmmo -= weaponScript.AmmoConsumption;
    }
}
