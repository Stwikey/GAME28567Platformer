using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public Vector2 playerInput;
    public Rigidbody2D rb2D;
    public Collider2D col;
    public List<Collider2D> colliders = new List<Collider2D>();

    public bool isLeft = true;

    public enum FacingDirection
    {
        left, right
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

    }

    void Update()
    {
        playerInput = new Vector2();

        // The input from the player needs to be determined and
        // then passed in the to the MovementUpdate which should
        // manage the actual movement of the character.

        //player moving right
        if(Keyboard.current.rightArrowKey.isPressed){
            playerInput = transform.right;
        }
        //player moving left
        else if(Keyboard.current.leftArrowKey.isPressed){
            playerInput = -transform.right;
        }else{
        //player is not moving
            playerInput = Vector2.zero;
        }
        MovementUpdate(playerInput);


    }

    private void MovementUpdate(Vector2 playerInput)
    {
        //move the player horizontally
        /**transform.position += speed * (Vector3)playerInput * Time.deltaTime;
        Debug.Log("Position: " + transform.position);
        **/
        
        //move the player horizontally
        rb2D.AddForce(speed * (Vector3)playerInput);

    }

    public bool IsWalking()
    {
        //if the player isnt moving
        if(playerInput == Vector2.zero){
            return false;
        }else{//if the player is moving
            return true;
        }
    }
    public bool IsGrounded()
    {
        //player is in the air
        if(col.GetContacts(colliders) == 0){
            return false;
        }else{//player is touching the ground
            return true;
        }
    }

    public FacingDirection GetFacingDirection()
    {
        //stores last direction of player
        if((Vector3)playerInput == -transform.right){
            isLeft = true;
        }
        if ((Vector3)playerInput == transform.right){
            isLeft = false;
        }

        //flips the player to the correct direction
        if(isLeft){
            return FacingDirection.left;
        }else{
            return FacingDirection.right;
        }
    }
}
