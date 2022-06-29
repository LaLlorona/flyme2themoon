using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D playerRigidbody;

    public float propulsionForce = 5.0f;
    public float horizontalSpeed = 3.0f;

    public float maxFallSpeed = -5.0f;

    public float maxUpSpeed = 3.0f;

    public float maxHorizontalSpeed = 2.0f;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
       
        if (Input.GetAxis("Jump") > 0)
        {
           
            playerRigidbody.AddForce(Vector2.up * propulsionForce, ForceMode2D.Force);
        }

        if (Input.GetAxis("Horizontal") !=0 )
        {
         
            playerRigidbody.AddForce(Vector2.right * horizontalSpeed * Input.GetAxis("Horizontal"));
        }

        if (playerRigidbody.velocity.y < maxFallSpeed)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, maxFallSpeed);
        }

        if (playerRigidbody.velocity.y > maxUpSpeed)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, maxUpSpeed);
        }

        if (playerRigidbody.velocity.x > maxHorizontalSpeed)
        {
            playerRigidbody.velocity = new Vector2(maxUpSpeed, playerRigidbody.velocity.y);
        }

        if (playerRigidbody.velocity.x < -maxHorizontalSpeed)
        {
            playerRigidbody.velocity = new Vector2(-maxUpSpeed, playerRigidbody.velocity.y);
        }



    }
}
