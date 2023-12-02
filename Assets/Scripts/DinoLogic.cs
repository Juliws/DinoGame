using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoLogic : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float circleradio;

    [SerializeField] private AudioClip jump;

    private Rigidbody2D dinoRig;
    private Animator dinoAnim;
    //public bool m_bajo = false;


    void Start()
    {
        dinoRig = GetComponent<Rigidbody2D>();
        dinoAnim = GetComponent<Animator>();
    }

    
    void Update()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundcheck.position, circleradio, ground);
        dinoAnim.SetBool("IsGrounded", isGrounded);

        if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
        {
            if (isGrounded)
            {
                dinoRig.AddForce(Vector2.up * jumpForce);
                SoundsControl.Instance.Playsound(jump);

                /*if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    m_bajo = true;
                }
                else m_bajo = false;
                
                if (m_bajo == true)
                {
                    dinoAnim.SetBool("Down", true);
                }
                if (m_bajo == false)
                {
                    dinoAnim.SetBool("Down", false);
                }*/
            }
            
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundcheck.position, circleradio);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) 
        { 
        GameManager.Instance.ShowgameOverScreen();
        dinoAnim.SetTrigger("Lose");
        Time.timeScale = 0f;
        }
    }
}
