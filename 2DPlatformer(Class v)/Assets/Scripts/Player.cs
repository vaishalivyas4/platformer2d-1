using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    float h, v;

    float health;

    public float maxHealth = 300;

    public float jumpForce;

    float groundRayLen;

    [SerializeField]
    float moveSpeed = 20f;

    float healthPerc;

    float curSpeed;

    Rigidbody2D rb;

    Animator anim;

    float curScale = 0.3f;

    public Transform healthFillImage;

    Vector2 startPos;

    public string jumpableLayer;

    public Text healthText;

    bool isFalling = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundRayLen = (GetComponent<BoxCollider2D>().bounds.extents.y);
        health = maxHealth;
    }

    public void Footstep()
    {
        Debug.Log("Footstep");
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");

        if (h>0)
        {
            curScale = 0.3f;
        }
        else if(h<0)
        {
            curScale = -0.3f;
        }

        health = Mathf.Clamp(health, 0, maxHealth);

        healthPerc = health / maxHealth;

        healthPerc = Mathf.Clamp(healthPerc,0,1);

        healthText.text = "" + Mathf.RoundToInt(healthPerc * 100) + "%";

        healthFillImage.localScale = new Vector2(healthPerc, healthFillImage.localScale.y);

        if (Input.GetKeyDown(KeyCode.J))
        {
            health -= 20f;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            health += 20f;
        }

        #region Jump Mechanic
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce);
            anim.SetTrigger("Jump");
        }
        #endregion

        if (rb.velocity.y <= 0 && !isFalling && !IsGrounded())
        {
            isFalling = true;   
            anim.SetTrigger("Fall");
        }

        if (isFalling && IsGrounded())
        {
            isFalling = false;
        }

        transform.localScale = new Vector2(curScale, 0.3f);

        rb.velocity = new Vector2(h * moveSpeed,rb.velocity.y);

        curSpeed = rb.velocity.magnitude;

        anim.SetFloat("speed",curSpeed);
    }

    bool IsGrounded()
    {
        startPos = transform.position;
        startPos.y = transform.position.y - (groundRayLen + 0.01f);
        return Physics2D.Raycast(startPos, -transform.up, 0.1f);
    }

}
