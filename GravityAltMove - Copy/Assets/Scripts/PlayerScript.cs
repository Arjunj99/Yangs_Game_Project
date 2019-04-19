using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{


	
	public float speed = 6f;
    public float sprintSpeed = 10f;
	public float gravity = 15f;
	public GameObject playerBody;
    public float distanceBelow;
    public float groundHeight;
    public GameObject playerReferencePoint;
    public AudioSource footstep;

	private Vector3 moveDirection = Vector3.zero;
	private Vector3 gravityDirection = Vector3.zero;
    private CharacterController cc;
    private Collider character_collider;
    private bool isJumping;


	[SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private KeyCode sprintKey;


    void Start()
    {
        cc = GetComponent<CharacterController>();
        character_collider = GetComponent<Collider>();
        
    }

    private void playFootstep()
    {

        GameObject Environment = GameObject.Find("Environment");
        GroundSensorConsolidated gsc = Environment.GetComponent<GroundSensorConsolidated>();
        
        footstep.pitch = 1f;
        if(Input.GetKey(KeyCode.LeftShift))
                footstep.pitch = 1.5f;

        if(gsc.playerTouchingGround == true && moveDirection != Vector3.zero)
        {
            //Debug.Log("playing footstep");
            footstep.enabled = true;
            footstep.loop = true;

        }

        else if(gsc.playerTouchingGround == false || moveDirection == Vector3.zero)
        {
            //Debug.Log("stopping footstep");
            footstep.enabled = false;
            footstep.loop = false;
        }
        
    }

/* 
    Function:   Detects whether the player is currently in the air
    Invariants: groundHeight is already established
*/
    private bool isinAir()
    {
    		RaycastHit below;
			Physics.Raycast(playerBody.transform.position, -playerBody.transform.up, out below);
			distanceBelow = Vector3.Distance(below.point, playerReferencePoint.transform.position);

    		if(distanceBelow > groundHeight)
    			return (true);

    		else
    			return (false);
    }

/* 
    Function:   Gravity and player movement
    Invariants: Handles player wasd + space controls as well as relative gravity
*/
    void Update()
    {

        playFootstep();
    	gravityDirection = -playerBody.transform.up;

        //It works. Don't touch it.
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = playerBody.transform.TransformDirection(moveDirection);
		if(Input.GetKey(KeyCode.LeftShift))
            moveDirection *= sprintSpeed;
        else
            moveDirection *= speed;

        cc.Move(moveDirection * Time.deltaTime);
        cc.Move(gravityDirection * Time.deltaTime * gravity);

        JumpInput();

    }

/* 
    Function:   Detects if the jump key is pressed, sets groundHeight
    Invariants: Player can not already be jumping
    Bugs: isJumping seems to not be doing anything. Test and take out later.
*/
     private void JumpInput()
    {
        if(Input.GetKeyDown(jumpKey) && !isJumping)
        {

            RaycastHit below;
            Physics.Raycast(playerBody.transform.position, -playerBody.transform.up, out below);
            groundHeight = Vector3.Distance(below.point, playerReferencePoint.transform.position);

            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

/* 
    Function:   Handles jumping with an animation curve
    Invariants: "iterations" is being used to prevent double jumping on an existing surface
*/
    private IEnumerator JumpEvent()
    {
        cc.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        int iterations = 0;

        do
        {
            iterations++;
            if(iterations > 50)
                break;

    		if(distanceBelow < 0f)
    			distanceBelow = 0f;

            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            cc.Move(playerBody.transform.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;

        } while (isinAir() && cc.collisionFlags != CollisionFlags.Above);

        cc.slopeLimit = 45.0f;
        isJumping = false;
    }

    //Jumpinng base code courtesy: Acacia Developer (YT)


}
