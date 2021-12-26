using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
  public Weapon weapon;
  public Ammunition ammo;
  public PlayerController playerController;
  public GameObject projectile;
  public GameObject fireEffect;
  public Transform tipTransform;

  private float shotTimer;
  private float curTimer;
  private bool facingRight = true;

  public bool shooting = false;
  public int AmmoConsumption;
  public float curTimeBtwShots;
  public float offset;
  public int WeaponType = 1;


    // Start is called before the first frame update
    void Start()
    {
      ammo = GetComponentInParent<Ammunition>();
      playerController = GetComponentInParent<PlayerController>();

      curTimer = curTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
    //  curTimeBtwShots--;
    //  Shoot();
    if(WeaponType == 1) {
      Shoot();
    } else if(WeaponType == 2) {
      AutoShoot();
    } else if(WeaponType == 3) {
      ShotgunShoot();
    } else {
      Debug.Log("Not a Valid Weapon Type.");
    }
    }

    void Shoot() {
      if (Input.GetMouseButton(0) && ammo.IsThereEnough()) {
        shooting = true;
        if(curTimeBtwShots <= 0f) {
          ammo.Shot();
          Instantiate(fireEffect, tipTransform.transform.position, Quaternion.identity);
          Instantiate(projectile, tipTransform.position, transform.rotation);
          curTimeBtwShots = curTimer;
          //Instantiate projcurShotTimer = shotTimer
        }
      } else {
        shooting = false;
        curTimeBtwShots -= Time.deltaTime;
      }
    //  curTimer -= Time.deltaTime;
    }

    void AutoShoot() {
      curTimeBtwShots -= Time.deltaTime;
      if(curTimeBtwShots <= 0f) {
     //    shooting = false;
         if (Input.GetMouseButton(0) && ammo.IsThereEnough()){
         shooting = true;
         ammo.Shot();
         Instantiate(fireEffect, tipTransform.transform.position, Quaternion.identity);
         Instantiate(projectile, tipTransform.position, transform.rotation);
         curTimeBtwShots = curTimer;
         curTimeBtwShots -= Time.deltaTime;
       } else {
         shooting = false;
         curTimeBtwShots -= Time.deltaTime;
       }
       }
    }

    void ShotgunShoot() {
      if (Input.GetMouseButton(0) && ammo.IsThereEnough()) {
        shooting = true;
        if(curTimeBtwShots <= 0f) {
          ammo.Shot();
          Instantiate(fireEffect, tipTransform.transform.position, Quaternion.identity);
          Instantiate(projectile, tipTransform.position, transform.rotation);

          curTimeBtwShots = curTimer;
          //Instantiate projcurShotTimer = shotTimer
        }
      } else {
        shooting = false;
        curTimeBtwShots -= Time.deltaTime;
      }
    //  curTimer -= Time.deltaTime;
    }


    void FixedUpdate() {
      Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
      float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

      Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

      if(facingRight == false && this.transform.position.x < mousePos.x){
        Flip();
      } else if(facingRight == true && this.transform.position.x > mousePos.x){
        Flip();
      }

    }

    public void Flip(){

      facingRight = !playerController.facingRight;
      Vector3 Scaler = transform.localScale;
      Scaler.x *= -1;
      Scaler.y *= -1;
      transform.localScale = Scaler;
    }
}
