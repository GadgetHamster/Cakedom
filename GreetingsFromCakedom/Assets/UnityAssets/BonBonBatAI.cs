using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonBonBatAI : MonoBehaviour
{

  public DestroyThisObject a;
  public DestroyThisObject b;
  public DestroyThisObject c;
  public Animator anim;
  public Animator LeftWingAnim;
  public Animator RightWingAnim;
  public UnparentTrail LeftWingUnparent;
  public UnparentTrail RightWingUnparent;
  public UnparentTrail BonBatBodyUnparent;
  public GameObject LeftWing;
  public GameObject RightWing;
  public GameObject player;
  public GameObject enemyDeath;

  private Rigidbody2D rb;
  public Rigidbody2D BatRb;

  public int movementMagnitude;
  public int SwoopMagnitude;
  public int timeBtwJumps;
  public float hoverHeight;
  public float damage;
  public float health;
  private int timeBtwJumps2;
  private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
      rb = gameObject.GetComponent<Rigidbody2D>();
      timeBtwJumps2 = timeBtwJumps;
    //  anim = gameObject.GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
      if (dead == true) {
        return;
      }
        LeftRight();
        UpDown();
        Swoop();
    }

    void FixedUpdate()
    {
      if (dead == true) {
        return;
      }
      checkHealth();

    }



    void LeftRight()
    {
    //  timeBtwJumps = timeBtwJumps - 1;
    if(this.transform.position.x < player.transform.position.x){
    //  timeBtwJumps = timeBtwJumps2;
      rb.AddForce(Vector2.right * movementMagnitude * Time.deltaTime);
    //  rb.AddForce(Vector2.up * movementMagnitude * Time.deltaTime);

    } else if(this.transform.position.x > player.transform.position.x){
    //  timeBtwJumps = timeBtwJumps2;
      rb.AddForce(Vector2.left * movementMagnitude * Time.deltaTime);
    //  rb.AddForce(Vector2.up * movementMagnitude * Time.deltaTime);
    } else {
      return;
    }
    }

    void UpDown()
    {
    //  timeBtwJumps = timeBtwJumps - 1;
    if(this.transform.position.y < player.transform.position.y + hoverHeight){
    //  timeBtwJumps = timeBtwJumps2;
      rb.AddForce(Vector2.up * movementMagnitude * Time.deltaTime * 5f);
    //  rb.AddForce(Vector2.up * movementMagnitude * Time.deltaTime);

  } else if(this.transform.position.y > player.transform.position.y + hoverHeight){
    //  timeBtwJumps = timeBtwJumps2;
      rb.AddForce(Vector2.down * movementMagnitude * Time.deltaTime * 5f);
    //  rb.AddForce(Vector2.up * movementMagnitude * Time.deltaTime);
    } else {
      return;
    }
    }

    void Swoop()
    {
      timeBtwJumps = timeBtwJumps - 1;
    if(timeBtwJumps < 0 && this.transform.position.y > player.transform.position.y + hoverHeight){ //this.transform.position.x < player.transform.position.x - 5f &&
      timeBtwJumps = timeBtwJumps2;
      rb.AddForce(Vector2.right * movementMagnitude * Time.deltaTime);
      rb.AddForce(Vector2.down * SwoopMagnitude * Time.deltaTime);
    } else if(timeBtwJumps < 0 && this.transform.position.y > player.transform.position.y + hoverHeight){ //this.transform.position.x > player.transform.position.x + 5f &&
      timeBtwJumps = timeBtwJumps2;
      rb.AddForce(Vector2.left * movementMagnitude * Time.deltaTime);
      rb.AddForce(Vector2.down * SwoopMagnitude * Time.deltaTime);
    } else {
      return;
    }
    }

    void checkHealth() {
      if (health <= 0 && dead == false) {
        dead = true;
        anim.SetTrigger("IsHurt");
        LeftWingAnim.SetTrigger("IsHurt");
        RightWingAnim.SetTrigger("IsHurt");

        gameObject.layer = 12;
    //    anim.SetBool("IsDead", true);
    //    LeftWingAnim.SetBool("IsDead", true);
    //    Debug.Log("Test LeftWing.");
    //    RightWingAnim.SetBool("IsDead", true);

        StartCoroutine(Die());

    //    LeftWingUnparent.Unparent();

    //    LeftWingAnim.enabled = false;

        Instantiate(enemyDeath, transform.position, Quaternion.identity);
        Destroy(gameObject, 10f);
      }
    }

    void TakeDamage(float amount)
  {
  //  if (dead == false){
      anim.SetTrigger("IsHurt");
      LeftWingAnim.SetTrigger("IsHurt");
      RightWingAnim.SetTrigger("IsHurt");


      health = health - amount;
  //  }
  }

    void Awake() {
      player = GameObject.Find("Player");
    }

    void OnCollisionEnter2D(Collision2D col)
  {
    DamageVars EnemyDamage = new DamageVars(damage, col.GetContact(0).point);

    col.gameObject.SendMessage("TakeDamage", EnemyDamage, SendMessageOptions.DontRequireReceiver);
  }


  public IEnumerator Die() // int CurrentAmmo
  {
    LeftWingAnim.SetBool("IsDead", true);
    RightWingAnim.SetBool("IsDead", true);
    anim.SetBool("IsDead", true);


    yield return new WaitForSeconds(1f);

    BatRb.freezeRotation = false;

    LeftWingAnim.enabled = false;
    RightWingAnim.enabled = false;
    anim.enabled = false;

    LeftWingUnparent.Unparent();
    RightWingUnparent.Unparent();
    BonBatBodyUnparent.Unparent();

    a.Destroy();
    b.Destroy();
    c.Destroy();
  }
}
