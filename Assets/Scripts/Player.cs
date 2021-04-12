using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Rigidbody2D m_Rb;
    [SerializeField] float m_Force;
    [SerializeField] Transform m_RaycastOrigin;
    [SerializeField] bool m_IsGrounded;
    [SerializeField] bool m_Jump;
    [SerializeField] float m_XLeftLimit;
    [SerializeField] Animator m_Anim;
    [SerializeField] float m_LastYPosition;
    [SerializeField] UIController m_UiController;
    [SerializeField] GameObject m_Shield;
    bool m_HasShield;
    bool m_AirJump;
    public int m_CollectedCoins;
    public float maxDistance;
    public bool gameIsActive;

    RaycastHit2D hit;

    void Start()
    {
        m_Rb = GetComponent<Rigidbody2D>();
        m_LastYPosition = transform.position.y;
        gameIsActive = true;
    }


    private void Update()
    {
        if (gameIsActive)
        {
            CheckForInput();
            CheckIfCharacterIsFalling();
            CheckForPlayerPosition();
            maxDistance += Time.deltaTime * 3f;
        }
    }

    private void CheckForPlayerPosition()
    {
        if (transform.position.x <= m_XLeftLimit)
        {
            m_UiController.ShowGameOverScreen();
        }
    }

    private void FixedUpdate()
    {
        CheckForGrounded();
        CheckForJump();
    }

    private void CheckForInput()
    {
        if (m_IsGrounded || m_AirJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if(m_AirJump == true && m_IsGrounded == false)
                {
                    m_AirJump = false;
                }
                m_Jump = true;
                m_Anim.SetTrigger("Jump");
            }
        }
    }

    private void CheckForGrounded()
    {
        hit = Physics2D.Raycast(m_RaycastOrigin.position, Vector2.down);

        if (hit.collider != null)
        {
            if (hit.distance < 0.1f)
            {
                m_IsGrounded = true;
                m_Anim.SetBool("IsGrounded", true);
                //Debug.Log(hit.transform.name);
            }
            else
            {
                m_IsGrounded = false;
                m_Anim.SetBool("IsGrounded", false);
            }
        }
        else
        {
            m_IsGrounded = false;
            m_Anim.SetBool("IsGrounded", false);
        }

        Debug.DrawRay(m_RaycastOrigin.position, Vector2.down, Color.green);
    }

    private void CheckIfCharacterIsFalling()
    {
        if (transform.position.y < m_LastYPosition)
        {
            m_Anim.SetBool("IsFalling", true);
        }
        else
        {
            m_Anim.SetBool("IsFalling", false);
        }
        m_LastYPosition = transform.position.y;
    }

    private void CheckForJump()
    {
        if (m_Jump == true)
        {
            m_Jump = false;
            m_Rb.AddForce(Vector2.up * m_Force, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            if(m_HasShield)
            {
                DeactivateShield();
                Destroy(collision.gameObject);

            }else
            {
                m_UiController.ShowGameOverScreen();
                gameObject.SetActive(false);
            }
            
        }

        if(collision.gameObject.CompareTag("DeathBox"))
        {
            m_UiController.ShowGameOverScreen();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Collectable"))
        {
            m_CollectedCoins++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("DoubleJumpCollectable"))
        {
            m_AirJump = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("ShieldCollectable"))
        {
            m_HasShield = true;
            m_Shield.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    void DeactivateShield()
    {
        m_Shield.SetActive(false);
        m_HasShield = false;
    }
}
