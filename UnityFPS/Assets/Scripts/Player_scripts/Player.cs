using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {

    CharacterController cc;

    Animator animator;
    Score score;

    public AudioClip fire1Audio;
    public AudioClip fire2Audio;
    public AudioClip jumpAudio;
    public AudioClip walkAudio;

    float walktime = 0;

    private AudioSource sourceAudio;

    public float speed;
    float rotationSpeed;
    float jumpSpeed;
    float gravity;
    bool isSprinting = false;
    bool isAttacking = true;

    public bool speedBoosted = false;
    public bool damageBoosted = false;
    public bool scoreBoosted = false;

    private Vector3 moveDirection;

    public Projectile projectilePrefab1;
    public Projectile projectilePrefab2;

    //public Melee meleeobject;

    private int weapon = 1;

    private float cooldown;
    private float atkCooldown;

    private float hazInvuln = 0.0f;

    public float boostTime = 0.0f;

    public Transform projectileSpawn;

    public HUD hud;

    // Use this for initialization
    void Start () {
        score = GameObject.FindWithTag("Score").GetComponent<Score>();
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        sourceAudio = GetComponent<AudioSource>();

        if (!cc) {
            cc = gameObject.AddComponent<CharacterController>();
        }

        if (speed <= 0) {
            speed = 5.0f;
            Debug.LogError("Speed is set to default 5f");
        }

        if (rotationSpeed <= 0) {
            rotationSpeed = 6.0f;
            Debug.LogError("rotationSpeed is set to default 6f");
        }

        if (jumpSpeed <= 0) {
            jumpSpeed = 5.0f;
            Debug.LogError("jumpSpeed is set to default 5f");
        }

        if (gravity <= 0) {
            gravity = 9.8f;
            Debug.LogError("Speed is set to default 9.8f");
        }
        animator.SetBool("weapon1", true);
    }
	
	// Update is called once per frame
	void Update () {
        //handling of boosts
        walktime -= Time.deltaTime;
        boostTime -= Time.deltaTime;

        //speed boost
        if (speedBoosted && boostTime > 0.0f)
        {
            speed = 7.5f;
            
        }else if(speedBoosted && boostTime <= 0.0f)
        {
            speed = 5.0f;
            speedBoosted = false;
        }

        //damage boost
        if (damageBoosted && boostTime > 0.0f)
        {
            projectilePrefab1.SetDamage(10);
            projectilePrefab2.SetDamage(30);
        }
        else if (damageBoosted && boostTime <= 0.0f)
        {
            projectilePrefab1.SetDamage(5);
            projectilePrefab2.SetDamage(15);
            damageBoosted = false;
        }

        //score boost
        if (scoreBoosted && boostTime > 0.0f)
        {
            score.boosted = true;
        }
        else if (scoreBoosted && boostTime <= 0.0f)
        {
            scoreBoosted = false;
            score.boosted = false;
           
        }
        hud.UpdateBuff(speedBoosted, "speed");
        hud.UpdateBuff(damageBoosted, "damage");
        hud.UpdateBuff(scoreBoosted, "score");


        //weapon cooldowns
        if (weapon == 1)
        {
            cooldown = 0.15f;

        }else
        {
            cooldown = 1.0f;
        }

        //ataack cooldown handling
        atkCooldown -= Time.deltaTime;

        if (atkCooldown > 0)
        {
            isAttacking = false;
        }
        else if (atkCooldown <= 0)
        {
            isAttacking = true;
        }
        animator.SetBool("isShooting", !isAttacking);

        isSprinting = false;

        //movement handling
        if (cc.isGrounded) {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));

            moveDirection = transform.TransformDirection(moveDirection);

            moveDirection *= speed;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                isSprinting = true;
                
                moveDirection *= 2.0f;
                Debug.Log("zoom zoom");
            }

            if (Input.GetButtonDown("Jump")) {
                sourceAudio.PlayOneShot(jumpAudio);
                moveDirection.y = jumpSpeed;
            }


        }
        animator.SetBool("isGrounded", cc.isGrounded);
        animator.SetBool("isSprinting", isSprinting);
        

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * 1 / 2, 0);

        moveDirection.y -= gravity * Time.deltaTime;

        if(Mathf.Abs(moveDirection.x) > 0 || Mathf.Abs(moveDirection.z) > 0)
        {
            animator.SetFloat("speed", 1);
            if (cc.isGrounded)
            {
                
                if (walktime <= 0)
                {
                    sourceAudio.PlayOneShot(walkAudio);
                    if(cc.isGrounded && isSprinting == true)
                    {
                        walktime = 0.5f;
                    }
                    else
                    {
                        walktime = 1.0f;
                    }
                }
            }
        }
        else
        {
            animator.SetFloat("speed", 0);
        }

        animator.SetFloat("vspeed", moveDirection.y);

        cc.Move(moveDirection * Time.deltaTime);

        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * 5.0f, Color.red);

        if(Physics.Raycast(transform.position, transform.forward, out hit, 5.0f)) {
            Debug.Log("you got hit foo" + hit.collider.name);
           
        }
        //checking if the player is allowed to attack at this moment
        if (!isSprinting && cc.isGrounded)
        {
            if (Input.GetButton("Fire1"))
            {
                if (isAttacking)
                {
                    Fire();
                }
            }
        }

        //weapon switching
        if (Input.GetKeyDown(KeyCode.Tab)) {
            Debug.Log("you hit tab");
            if (weapon == 1) {
                weapon = 2;
                animator.SetBool("weapon1", false);
                animator.SetBool("weapon2", true);

            }
            else {
                weapon = 1;
                animator.SetBool("weapon1", true);
                animator.SetBool("weapon2", false);
            }
        }

        if (Input.GetKeyDown(KeyCode.C)) {
            MeleeAtk();
        }
	}

    void MeleeAtk() {
        //need to implement/ ask how to properly control spawn axis
        //need to instantiate the melee object and have it traverse a 180degree rotation on the x axis paralel to the player 
        //starting from the left to the right, then have the melee destroy after it finishes the 180 degree.
    }
    
    //method that shoots the appropriate projectile for the selected weapon 
    void Fire() {
        Debug.Log("pew pew");
        if (weapon == 1)
        {
                if (projectilePrefab1 && projectileSpawn)
                {
                    Instantiate(projectilePrefab1, projectileSpawn.position, projectileSpawn.rotation);
                    sourceAudio.PlayOneShot(fire1Audio);
                }
            }
            else
            {
                if (projectilePrefab2 && projectileSpawn)
                {
                    Instantiate(projectilePrefab2, projectileSpawn.position, projectileSpawn.rotation);
                    sourceAudio.PlayOneShot(fire2Audio);
            }
        }
        atkCooldown = cooldown;
    }

    private void OnCollisionEnter(Collision c) {
        Debug.Log("colllllide" + c.gameObject.name);
    }

    //hazard handling
    private void OnTriggerStay(Collider c) {
        
        hazInvuln -= Time.deltaTime;

        if (c.CompareTag("Hazard"))
        {
            if (hazInvuln <= 0.0f)
            {
                c.GetComponent<Hazard>().Effect(gameObject);
                Debug.Log("its a hazard");
                hazInvuln = 1.5f;
            }
        }
    }

    //exiting hazard
    private void OnTriggerExit(Collider c)
    {
        Debug.Log("Triggggered" + c.gameObject.name);
        if (c.CompareTag("Hazard"))
        {
            speed = 5.0f;
            Debug.Log("hazard free since 93");
        }
    }

    //check for colliding
    private void OnControllerColliderHit(ControllerColliderHit c) {
        if (c.gameObject.CompareTag("Enemy")) {
            Debug.Log("ouchie you hit me " + c.gameObject.name);
        }
    }

    //method to set speedboost to true and set a timer for the buff
    public void SpeedBoost()
    {
        boostTime = 15.0f;
        speedBoosted = true;
    }

    //method to set scoreboost to true and set a timer for the buff
    public void ScoreBoost()
    {
        boostTime = 25.0f;
        scoreBoosted = true;
    }

    //method to set damageboost to true and set a timer for the buff
    public void DamageBoost()
    {
        boostTime = 10.0f;
        damageBoosted = true;
    }
}
