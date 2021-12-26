using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

  int layerMask = 1 << 10;


  public UnparentTrail Trail;

  public float speed;
  public float lifeTime;

  public GameObject destroyEffect;
  public GameObject enemyHit;

  public float damage;


  private void Start() {
    Invoke("DestroyProjectile", lifeTime);
  }

    void FixedUpdate()
    {
      layerMask = ~layerMask;

      RaycastHit2D Hit = Physics2D.Raycast(transform.position, Vector2.right, speed * Time.deltaTime, layerMask);
      if(Hit.collider != null && Hit.collider.gameObject.tag != "Player")
      {
        transform.Translate(Vector2.right * Hit.distance);
      } else {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
      }
    }

    void DestroyProjectile() {
      Instantiate(destroyEffect, transform.position, Quaternion.identity);
      Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
  {
    Trail.Unparent();
    col.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
    if (col.gameObject.tag == ("Walls_Floors")) {
      Instantiate(destroyEffect, transform.position, Quaternion.identity);
      Destroy(gameObject);
    }
    if (col.gameObject.tag == ("Enemy")) {
        Instantiate(enemyHit, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


  }




}
