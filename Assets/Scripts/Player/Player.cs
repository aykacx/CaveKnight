using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Components
    Rigidbody2D rb2d;
    Animator playerAnimator;
    #endregion

    HashSet<Collider2D> currentlyTouching = new HashSet<Collider2D>();

    [SerializeField]
    float moveSpeed;
    [SerializeField]
    int jumpForce;

    [SerializeField] GameObject inGameUI;
    [SerializeField] GameObject endLevelUI;
    [SerializeField] GameObject deathUI;

    [Header("Level Buttons")]
    [SerializeField] Button btnLevel2;
    [SerializeField] Button btnLevel3;
    [SerializeField] Button btnLevel4;
    [SerializeField] Button btnLevel5;
    [SerializeField] Button btnLevel6;
    [Header(" ")]

    [Header("Sounds")]
    [SerializeField] GameObject jumpSound;
    [Header(" ")]

    public PlayerHealthBar healthBar;
    public GameObject goldParticle;
    public GameObject moveParticle;

    private float horizontalMove;
    private bool lookingRight = true;
    private bool isGround;
    private Vector2 jump;

    private int maxHealth = 100;
    public int currentHealth;

    int levelActivate = 0;

    public GameObject dust;
    //Ufuk test
    //

    private void Awake()
    {
        levelActivate = PlayerPrefs.GetInt("LevelActivate");
        if (levelActivate >= 1)
        {
            btnLevel2.interactable = true;
        }
        if (levelActivate >= 2)
        {
            btnLevel3.interactable = true;
            btnLevel2.interactable = true;
        }
        if (levelActivate >= 3)
        {
            btnLevel4.interactable = true;
            btnLevel3.interactable = true;
            btnLevel2.interactable = true;
        }
        if (levelActivate >= 4)
        {
            btnLevel5.interactable = true;
            btnLevel4.interactable = true;
            btnLevel3.interactable = true;
            btnLevel2.interactable = true;
        }
        if (levelActivate >= 5)
        {
            btnLevel6.interactable = true;
            btnLevel5.interactable = true;
            btnLevel4.interactable = true;
            btnLevel3.interactable = true;
            btnLevel2.interactable = true;
        }
        gameObject.SetActive(false);
    }

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        jump = new Vector2(0.0f, 5f);
        //isPlayerActive = true;
    }
    private void Update()
    {
        healthBar.SetHealth(currentHealth);
    }
    void FixedUpdate()
    {
        //if (!isPlayerActive)
        //    return;

        //horizontalMove = Input.GetAxis("Horizontal");
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        rb2d.velocity = new Vector2((horizontalMove * moveSpeed) * Time.deltaTime, rb2d.velocity.y);
        if (lookingRight == true && horizontalMove < 0)
        {
            Flip();
        }
        else if (lookingRight == false && horizontalMove > 0)
        {
            Flip();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            currentlyTouching.Add(collision.collider);
            isGround = true;
            playerAnimator.SetBool("Grounded", true);
        }
        if (collision.collider.CompareTag("Obstacle"))
        {
            //var obstacle = collision.gameObject.GetComponent<ObstacleController>();
            //TakeDamage(obstacle.Damage);
            TakeDamage(10);
            currentlyTouching.Add(collision.collider);
            isGround = true;
            playerAnimator.SetBool("Grounded", true);
        }
        if (collision.gameObject.tag == "Finish1")
        {
            horizontalMove = 0;
            currentHealth = 100;
            levelActivate = 1;
            inGameUI.SetActive(false);
            endLevelUI.SetActive(true);
            if (levelActivate >= 1)
            {
                btnLevel2.interactable = true;
            }
            PlayerPrefs.SetInt("LevelActivate", levelActivate);
            PlayerPrefs.Save();
            Debug.Log(levelActivate);
        }
        if (collision.gameObject.tag == "Finish2")
        {
            horizontalMove = 0;
            currentHealth = 100;
            levelActivate = 2;
            inGameUI.SetActive(false);
            endLevelUI.SetActive(true);
            if (levelActivate >= 2)
            {
                btnLevel3.interactable = true;
            }
            PlayerPrefs.SetInt("LevelActivate", levelActivate);
            PlayerPrefs.Save();
        }
        if (collision.gameObject.tag == "Finish3")
        {
            horizontalMove = 0;
            currentHealth = 100;
            levelActivate = 3;
            inGameUI.SetActive(false);
            endLevelUI.SetActive(true);
            if (levelActivate >= 3)
            {
                btnLevel4.interactable = true;
            }
            PlayerPrefs.SetInt("LevelActivate", levelActivate);
            PlayerPrefs.Save();
        }
        if (collision.gameObject.tag == "Finish4")
        {
            horizontalMove = 0;
            currentHealth = 100;
            levelActivate = 4;
            inGameUI.SetActive(false);
            endLevelUI.SetActive(true);
            if (levelActivate >= 4)
            {
                btnLevel5.interactable = true;
            }
            PlayerPrefs.SetInt("LevelActivate", levelActivate);
            PlayerPrefs.Save();
        }
        if (collision.gameObject.tag == "Finish5")
        {
            horizontalMove = 0;
            currentHealth = 100;
            levelActivate = 5;
            inGameUI.SetActive(false);
            endLevelUI.SetActive(true);
            if (levelActivate >= 5)
            {
                btnLevel6.interactable = true;
            }
            PlayerPrefs.SetInt("LevelActivate", levelActivate);
            PlayerPrefs.Save();
        }
        if (collision.gameObject.tag == "Finish6")
        {
            horizontalMove = 0;
            currentHealth = 100;
            levelActivate = 6;
            inGameUI.SetActive(false);
            endLevelUI.SetActive(true);
            PlayerPrefs.SetInt("LevelActivate", levelActivate);
            PlayerPrefs.Save();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            currentlyTouching.Remove(collision.collider);
            isGround = currentlyTouching.Count > 0;
            playerAnimator.SetBool("Grounded", false);
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            currentlyTouching.Remove(collision.collider);
            isGround = currentlyTouching.Count > 0;
            playerAnimator.SetBool("Grounded", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "CanDelete")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "GoldBag")
        {
            var instantiatedParticle = Instantiate(goldParticle, collision.transform.position, Quaternion.identity);
            GoldText.goldAmount += 5;
            Destroy(collision.gameObject, 0.3f);

        }
        if (collision.gameObject.tag == "Gold")
        {
            var instantiatedParticle = Instantiate(goldParticle, collision.transform.position ,Quaternion.identity);
            GoldText.goldAmount += 1;
            Destroy(collision.gameObject, 0.2f);
        }
        if (collision.gameObject.tag == "GoldChest")
        {
            var instantiatedParticle = Instantiate(goldParticle, collision.transform.position, Quaternion.identity);
            GoldText.goldAmount += 15;
            Destroy(collision.gameObject, 2f);
        }
    }
    #region Functions
    
    public void MoveRight()
    {
        horizontalMove = 1;
        if (isGround)
        {
            moveParticle.SetActive(true);
        }
    }
    public void MoveLeft()
    {
        horizontalMove = -1;
        if (isGround)
        {
            moveParticle.SetActive(true);
        }
    }
    public void Stop()
    {
        horizontalMove = 0;
        moveParticle.SetActive(false);
    }
    public void GetJump()
    {
        if (isGround)
        {
            rb2d.AddForce(jump * jumpForce);
            playerAnimator.SetTrigger("Jump");
            var instantiatedpart = Instantiate(dust, gameObject.transform.position, Quaternion.identity);
            var instantiatedJumpSound = Instantiate(jumpSound,gameObject.transform.position, Quaternion.identity);
            Destroy(instantiatedJumpSound, 1f);
            Destroy(instantiatedpart, 0.417f);
        }
    }
    private void Flip()
    {
        lookingRight = !lookingRight;
        transform.Rotate(new Vector3(0, 180, 0));
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        playerAnimator.SetTrigger("Hurt");
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
            currentHealth = 100;
        }
    }

    private void Die()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        inGameUI.SetActive(false);
        deathUI.SetActive(true);
        playerAnimator.SetTrigger("Death");
        Time.timeScale = 0.6f;
    }
    #endregion


    #region notes
    /*
    HashSet<Collider2D> currentlyTouching = new HashSet<Collider2D>();

    OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            currentlyTouching.Add(collision.collider);
            isGround = true;
        }
    }

    OnCollisionExit2D(Collision2D collision)
    {
        currentlyTouching.Remove(collision.collider);
        isGround = currentlyTouching.Count > 0;
    }
    */
    #endregion
    
}
