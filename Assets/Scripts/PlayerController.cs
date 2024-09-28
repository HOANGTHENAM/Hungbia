using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D playerCol;
    public float speed = 5f;
    bool canMove = true;
    Vector2 movement;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCol = rb.GetComponent<BoxCollider2D>();
    }
    private void OnEnable()
    {
        GameManager.OnGamePlay += EnableMovement;
        GameManager.OnGamePause += DisableMovement;
        GameManager.OnGameOver += DisableMovement;
    }
    public void OnDisable()
    {
        GameManager.OnGamePlay -= EnableMovement;
        GameManager.OnGamePause -= DisableMovement;
        GameManager.OnGameOver -= DisableMovement;
    }
    
    private void FixedUpdate()
    {
        if (!canMove)
        {
            return;
        }
        Movement();
    }
    private void Movement()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, 0);
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, -2f, 2f), rb.position.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bottle")
        {
            collision.gameObject.SetActive(false);
            AudioManager.Instance.PlaySfx(0);
            GameManager.Instance.IncreaseScore(1);
        }

        if (collision.gameObject.tag == "Milk")
        {   
            collision.gameObject.SetActive(false);
            AudioManager.Instance.PlaySfx(0);
            GameManager.Instance.SetGameOver();
        }
    }
    public void EnableMovement()
    {
        canMove = true;
    }
    public void DisableMovement()
    {
        canMove = false;
    }
}

