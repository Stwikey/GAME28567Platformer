using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public Vector2 playerInput;

    public bool isLeft = true;

    public enum FacingDirection
    {
        left, right
    }

    void Start()
    {
        
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
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
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
        return false;
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
