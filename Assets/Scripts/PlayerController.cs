using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody playerRB;
    public float moveSpeed;

    private Vector2 moveInput;

    public SpriteRenderer playerSR;
    public Animator playerAC;

    public Sprite blorboForward;
    public Sprite blorboBackward;

    private bool movingBack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        playerRB.velocity = new Vector3(moveInput.x * moveSpeed, playerRB.velocity.y, moveInput.y * moveSpeed);

        if(playerSR.flipX && moveInput.x < 0){
            playerSR.flipX = false;
        } else if(!playerSR.flipX && moveInput.x > 0){
            playerSR.flipX = true;
        }

        if(!movingBack && moveInput.y > 0){
            movingBack = true;
            playerSR.sprite = blorboBackward;
        } else if(movingBack && moveInput.y < 0){
            movingBack = false;
            playerSR.sprite = blorboForward;
        }
        playerAC.SetBool("movingBackwards", movingBack);
    }
}
