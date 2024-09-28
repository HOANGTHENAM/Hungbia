using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    GameManager gameManager;
    public float speed;
    Rigidbody2D rb;
    bool canMove = true;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnEnable()
    {
        GameManager.OnGamePlay += EnableMove;
        GameManager.OnGamePause += DisableMove;
        GameManager.OnGameOver += DisableMove;
    }
    public void OnDisable()
    {
        GameManager.OnGamePlay -= EnableMove;
        GameManager.OnGamePause -= DisableMove;
        GameManager.OnGameOver -= DisableMove;
    }
    private void Start()
    {
        speed = Random.Range(50f, 100f);
    }
    private void FixedUpdate()
    {
        if(!canMove)
        {
            rb.velocity = Vector3.zero;
            return;
        }
        rb.velocity = new Vector2(rb.velocity.x, speed * Vector2.down.y * Time.fixedDeltaTime);

    }
    public void EnableMove()
    {
        canMove = true;
        rb.isKinematic = false;
    }
    public void DisableMove()
    {
        canMove = false;
        rb.isKinematic = true;
    }
}
