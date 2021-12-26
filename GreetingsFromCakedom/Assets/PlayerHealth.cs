using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{

  public GameObject HealthUpParticle;
  public GameObject ShieldUpParticle;
  public GameObject AmmoMagUpParticle;


  public bool isRegening;
  public float KnockBackTime;
  private float MaxKnockBackTime;

  public Slider Health;
  public Slider Shield;

////////////////////////////
  public float CurrentHealth = 100;
  string strCurrentHealth;

  public float MaxHealth = 100;
  string strMaxHealth;
////////////////////////////
public float CurrentShield = 0;
string strCurrentShield;

public float MaxShield = 0;
string strMaxShield;
////////////////////////////

  Rigidbody2D rb;

  public GameObject Player;
  public GameObject deathParticle;
//  string blabla = CurrentHealth + "/" + MaxHealth;
//  GUILayout.Label(CurrentHealth.ToString()); // Works

  PlayerController playerController;
  Ammunition ammunition;


  public Text HealthText;
  public Text ShieldText;

    void Start()
    {
      MaxKnockBackTime = KnockBackTime;
     rb = this.GetComponent<Rigidbody2D>();
     playerController = GetComponent<PlayerController>();
     ammunition = GetComponent<Ammunition>();

          StartCoroutine(RegenShield());


    }

    void FixedUpdate()
    {
      CheckKnockBackTimer();
      CheckDie();

      Shield.maxValue = MaxShield;
      string strCurrentShield = CurrentShield.ToString();
      string strMaxShield = MaxShield.ToString();
      Shield.value = CurrentShield;

      ShieldText.text = (strCurrentShield + "/" + strMaxShield);

      Health.maxValue = MaxHealth;
      string strCurrentHealth = CurrentHealth.ToString();
      string strMaxHealth = MaxHealth.ToString();
      Health.value = CurrentHealth;

      HealthText.text = (strCurrentHealth + "/" + strMaxHealth);


      /*if(CurrentShield < 0)
     {
     CurrentHealth = CurrentHealth + CurrentShield;
     CurrentShield = 0;
     } */
     isRegening = true;

     if(isRegening == true)
     {
  //     StartCoroutine(RegenShield());
     }

    }

  /*  void TakeDamage(float amount, Vector2 hitSource) {
      if(CurrentHealth >= 0)
      {
      CurrentHealth = CurrentHealth - amount;

      Vector2 PlayerPos = (Vector2)this.transform.position - hitSource;

      PlayerPos = PlayerPos.normalized;

      rb.AddForce(PlayerPos * amount);

      }
    } */

    void TakeDamage(DamageVars info) {
      if(CurrentShield > 0)
      {
      CurrentShield = CurrentShield - info.Damage;
      if(CurrentShield < 0)
      {
        CurrentHealth = CurrentHealth + CurrentShield;
        CurrentShield = 0;
      }


      Debug.Log(CurrentShield);

      }  else if(CurrentShield == 0)
       {
       CurrentHealth = CurrentHealth - info.Damage;
       //CurrentShield = 0;
       }
      /*else if(CurrentShield < 0)
      {
      CurrentHealth = CurrentHealth + CurrentShield;
      CurrentShield = 0;

      playerController.enabled = false;
      KnockBackTime = MaxKnockBackTime;
  //    Instantiate(deathParticle, this.transform.position, Quaternion.identity);

      Vector2 PlayerPos = (Vector2)this.transform.position - info.HitSource;
      //+ Vector2.up * 0.01f

      PlayerPos = PlayerPos.normalized;

      rb.AddForce(Vector2.up * -1f);
      rb.AddForce(PlayerPos * 300f);

      } */

      playerController.enabled = false;
      KnockBackTime = MaxKnockBackTime;
  //    Instantiate(deathParticle, this.transform.position, Quaternion.identity);

      Vector2 PlayerPos = (Vector2)this.transform.position - info.HitSource;
      //+ Vector2.up * 0.01f

      PlayerPos = PlayerPos.normalized;

      rb.AddForce(Vector2.up * -1f);
      rb.AddForce(PlayerPos * 300f);
    }

    public IEnumerator RegenShield() // int CurrentAmmo
    {
      //while(isRegening == true) //weapon.shooting == false && CurrentAmmo < MaxAmmo
    //  {
    if(CurrentShield == MaxShield)
    {
      yield return new WaitForSeconds(1);
      CurrentShield = CurrentShield;
      StartCoroutine(RegenShield());  // CurrentAmmo
    } else {
      Debug.Log("Regening Shield...");
      yield return new WaitForSeconds(1);
      Debug.Log("Stopping...");
      CurrentShield = CurrentShield + 1;
      isRegening = false;
  //  } else {
        StartCoroutine(RegenShield());
  //    }
    }
    }


    void CheckKnockBackTimer() {
      KnockBackTime = KnockBackTime - 1;
      if (KnockBackTime <= 0) {
        playerController.enabled = true;
    }
  }

    void CheckDie() {
      if (CurrentHealth <= 0) {

        playerController.speed = 0f;

        Destroy(Player, 1f);
        Instantiate(deathParticle, this.transform.position, Quaternion.identity);

      }
    }

    void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == ("PlayerHealthUp")) {
      MaxHealth = MaxHealth + 20f;
      CurrentHealth = CurrentHealth + 20f;
      Instantiate(HealthUpParticle, this.transform.position, Quaternion.identity);

      Destroy(other.gameObject);

  }
  if (other.gameObject.tag == ("PlayerCurHealthUp")) {
    CurrentHealth = CurrentHealth + 10f;
    if(CurrentHealth > MaxHealth) {
      CurrentHealth = MaxHealth;
    }
    Instantiate(HealthUpParticle, this.transform.position, Quaternion.identity);

    Destroy(other.gameObject);
}
  if (other.gameObject.tag == ("ShieldUp")) {
    MaxShield = MaxShield + 5f;
    CurrentShield = CurrentShield + 5f;
    Instantiate(ShieldUpParticle, this.transform.position, Quaternion.identity);

    Destroy(other.gameObject);

}  if (other.gameObject.tag == ("AmmoMagUp")) {
    ammunition.MaxAmmo = ammunition.MaxAmmo + 10;
    ammunition.CurrentAmmo = ammunition.CurrentAmmo + 10;
    Instantiate(AmmoMagUpParticle, this.transform.position, Quaternion.identity);

    Destroy(other.gameObject);

}

}
}
