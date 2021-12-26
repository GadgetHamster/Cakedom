using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DamageVars
{

  public float Damage;
  public Vector2 HitSource;

    public DamageVars(float damage, Vector2 hitSource)
    {
        this.Damage = damage;
        this.HitSource = hitSource;
    }

  //  public double X { get; }
  //  public double Y { get; }

    public override string ToString() => $"({Damage}, {HitSource})";
}

public class CakeAI : MonoBehaviour
{
  public GameObject player;
  public int movementMagnitude;
  private int timeBtwJumps2;
  public int timeBtwJumps;
  private Rigidbody2D rb;
  private bool facingRight = false;

  Animator anim;

  public float health;
  public GameObject enemyDeath;
  private bool dead = false;

  public float damage;





    // Start is called before the first frame update
    void Start()
    {
      rb = gameObject.GetComponent<Rigidbody2D>();
      anim = gameObject.GetComponent<Animator>();
      timeBtwJumps2 = timeBtwJumps;
    }

    // Update is called once per frame
    void Jump()
    {
      timeBtwJumps = timeBtwJumps - 1;
    if(this.transform.position.x < player.transform.position.x && timeBtwJumps < 0){
      timeBtwJumps = timeBtwJumps2;
      rb.AddForce(Vector2.right * movementMagnitude * Time.deltaTime);
      rb.AddForce(Vector2.up * movementMagnitude * Time.deltaTime);

    } else if(this.transform.position.x > player.transform.position.x && timeBtwJumps < 0){
      timeBtwJumps = timeBtwJumps2;
      rb.AddForce(Vector2.left * movementMagnitude * Time.deltaTime);
      rb.AddForce(Vector2.up * movementMagnitude * Time.deltaTime);
    } else {
      return;
    }
    }
    void FixedUpdate() {
      if (dead == true) {
        return;
      }
      checkHealth();
      Jump();
      if(facingRight == false && this.transform.position.x < player.transform.position.x){
        rb.AddForce(Vector2.right * movementMagnitude * Time.deltaTime);
        Flip();
      //  rb.AddForce(Vector2.up * movementMagnitude * Time.deltaTime);
      } else if(facingRight == true && this.transform.position.x > player.transform.position.x){
        rb.AddForce(Vector2.left * movementMagnitude * Time.deltaTime);
        Flip();
    //    rb.AddForce(Vector2.up * movementMagnitude * Time.deltaTime);
      }
    }

    void Flip(){
      facingRight = !facingRight;
      Vector3 Scaler = transform.localScale;
      Scaler.x *= -1;
      transform.localScale = Scaler;
    }

    void TakeDamage(float amount)
  {
  //  if (dead == false){
      anim.SetTrigger("IsHurt");
      health = health - amount;
  //  }
  }

  void checkHealth() {
    if (health <= 0 && dead == false) {
      dead = true;
      anim.SetTrigger("IsHurt");
      gameObject.layer = 12;
      anim.SetBool("IsDead", true);
      Instantiate(enemyDeath, transform.position, Quaternion.identity);
      Destroy(gameObject, 10f);
    }
  }

  void Awake() {
    player = GameObject.Find("Player");
    

  }
  void OnCollisionEnter2D(Collision2D col)
{
  DamageVars EnemyDamage = new DamageVars(damage, col.GetContact(0).point);

  col.gameObject.SendMessage("TakeDamage", EnemyDamage, SendMessageOptions.DontRequireReceiver);
}
}
