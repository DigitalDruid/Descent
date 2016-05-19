using UnityEngine;
using System.Collections;

public class PlayerMoveJoystick : MonoBehaviour {


	private float speed = 8f, maxVelocity = 4f;
    public float Speed { get { return speed; } set { speed = Speed; } }

	private Rigidbody2D myBody;
	private Animator anim;

	private bool moveLeft, moveRight;

	//calls GetComponet for Rigidbody and Animator as soon as game loads
	void Awake(){
		myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
    // Use this for initialization
    void Start() { }

    // Called every couple of frames
    void FixedUpdate()
    {
        // check if on-screen buttons are pressed
        if (moveLeft) { MovePlayer(-1); }
        else if (moveRight) { MovePlayer(1); }
        // if not, check for keyboard input
        else
        {
            float h = Input.GetAxisRaw("Horizontal");
            if (h != 0) {   // player is moving
                int m = (h > 0) ? 1 : -1;   // determines direction
                MovePlayer(m);
            } else {    // no input / player not moving
                StopMoving();
            }
        }
    }

    // makes sure both buttons aren't pressed
	public void SetMoveLeft(bool ml){
        moveLeft = ml;
        moveRight = !ml;
	}

	public void StopMoving(){
		moveLeft = moveRight = false;
		anim.SetBool ("Walk", false);
	}

    void MovePlayer(int direction)
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        if (vel < maxVelocity)
            forceX = direction * speed;

        Vector3 temp = transform.localScale;
        temp.x = direction * 1.3f;
        transform.localScale = temp;

        anim.SetBool("Walk", true);

        myBody.AddForce(new Vector2(forceX, 0));
    }
}