using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWeapon : MonoBehaviour
{
  /*Weapon weapon;

  private float x;
  private float y;
  private float z;

  private bool facingRight = true;
  public float offset;
  public GameObject projectile;
  public Transform shotPoint;

  public GameObject fireEffect;

  private float timeBtwShots;
  public float startTimeBtwShots;

  public bool shooting = false;

  Ammunition ammo;

  void Start() {
    ammo = GetComponent<Ammunition>();
    weapon = GetComponent<Weapon>();

  }

  private void Update() {
    Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

    if (timeBtwShots <= 0) {
      if(Input.GetMouseButton(0) && ammo.CurrentAmmo != 0 && ammo.CurrentAmmo >= ammo.AmmoConsumption) {
        shooting = true;
    //    weapon.shooting = true;
        ammo.CurrentAmmo = ammo.CurrentAmmo - ammo.AmmoConsumption;
        Instantiate(fireEffect, shotPoint.transform.position, Quaternion.identity);
        Instantiate(projectile, shotPoint.position, transform.rotation);
        x = shotPoint.transform.rotation.x;
        y = shotPoint.transform.rotation.y;
        z = shotPoint.transform.rotation.z;
      //  Instantiate(projectile, shotPoint.position, Quaternion.Euler(x, y, z + 90f));


        timeBtwShots = startTimeBtwShots;
      } else {
        shooting = false;
      //  weapon.shooting = false;
      }
    } else {
      timeBtwShots -= Time.deltaTime;
    }

  }
  void FixedUpdate() {
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    if(facingRight == false && this.transform.position.x < mousePos.x){
      Flip();
    } else if(facingRight == true && this.transform.position.x > mousePos.x){
      Flip();
    }

  }

  void Flip(){

    facingRight = !facingRight;
    Vector3 Scaler = transform.localScale;
    Scaler.x *= -1;
    Scaler.y *= -1;
    transform.localScale = Scaler;
  } */
}
