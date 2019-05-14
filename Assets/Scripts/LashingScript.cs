using UnityEngine;
using UnityEngine.UI;

/*
    Attached to: Caster object (child of camera)
    Function: Handles character direction lashing and object direction lashing
*/
public class LashingScript : MonoBehaviour
{

    //////// VARIABLE DECLERATIONS ////////
	public GameObject player;
        //Reference to the player

	public Camera fpsCam;
        //Reference to the camera
    
    private int shootController = 2;
        //BUGFIX: This variable ensures that Shoot() is only ever called once per click

    public Material lashedMaterial;
    public Material unlashedMaterial;
    public Text uiText;

    private int targetShootController = 2;
    private int lashShootController = 2;
    private bool targetIsSet = false;
    private Vector3 MoveableItemPosition;
    private RaycastHit targetSeeker;
    //private Text uiText;




     //////// FUNCTIONS ////////
/*
    Attached to:    Player
    Function:       Checks for Fire1 button input, and ensures it only shoots one
*/
    void Update()
    {

        RaycastHit target;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out target))
        {

            //Get reference to the object that the character is looking at
            GameObject pointTarget = GameObject.Find(target.transform.name);
            // uiText = pointTarget.GetComponent<Text>();
            // uiText.text = null;
            uiText.text = " ";
            if(pointTarget.tag == "Moveable")
            {
                RangeFinder RFscript = pointTarget.GetComponent<RangeFinder>();
                if(RFscript.isInRange)
                {
                    //Debug.Log("Looking at moveable object and in range");
                    uiText.text = "Lash";

                }
            }

        }

        
    	if(Input.GetButtonDown("Fire1"))
    	{
    		GravityShoot();
            shootController++;
    	}

        if(Input.GetButtonDown("Fire2") && targetIsSet == false)
        {
            TargetShoot();
            targetShootController++;
        }

        else if(Input.GetButtonDown("Fire2") && targetIsSet == true)
        {
            LashShoot();
            lashShootController++;
            targetIsSet = false;
        }

    }


/* 
    Function:   Changes the rotation of the player according to the surface they shoot
    Invariants: Surface needs to be straight. Have not tested on arced surfaces
*/
    void GravityShoot()
    {

        if(shootController % 2 == 0)
        {
            shootController++;

            RaycastHit hit;
            RaycastHit above;
            RaycastHit hitObject;

            //Shoots a ray out of the forward vector (where the crosshair is)
            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit) && 
            	(hit.transform.tag != "Moveable" && 
                 hit.transform.tag != "Breakable" && 
                 hit.transform.tag != "Deactivator" &&
                 hit.transform.tag != "LashIgnore"))
            {

                Debug.Log(hit.transform.name);

                //Assume the player shot at a perpendicular surface
                 Vector3 rotationBar = Vector3.Cross(hit.normal, player.transform.up);
                 hitObject = hit;

                //Check if the player aims straight up.
                if(Physics.Raycast(fpsCam.transform.position, player.transform.up, out above))
                {
                    //If so, use the natural right transform of the player body. 
                    //This transform does not change via camera
                    if(hit.transform.name == above.transform.name)
                    {
                        rotationBar = player.transform.right;
                        hitObject = above;
                    }
                }

                //Takes care of player rotation
                player.transform.RotateAround(player.transform.position, -rotationBar, Vector3.Angle(hit.normal, player.transform.up));

                if(GameObject.FindWithTag("LashedSurface") == true)
                {
	                GameObject previouslyLashedWall = GameObject.FindWithTag("LashedSurface");
	                previouslyLashedWall.transform.GetComponent<Renderer>().material = unlashedMaterial;
	                previouslyLashedWall.tag = "UnlashedSurface";
                }

                hitObject.transform.GetComponent<Renderer>().material = lashedMaterial;
                hitObject.transform.tag = "LashedSurface";

            }
        }
    }

/* 
    Function:   Identifies and gets the vector of a moveable object
    Invariants: Object must not be in motion 
*/
    void TargetShoot()
    {
        if(targetShootController % 2 == 0)
        {
            //Debug.Log("TargetShoot detected");
            targetShootController++;

            

            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out targetSeeker))
            {
                GameObject rangeFinder = GameObject.Find(targetSeeker.transform.name);
                RangeFinder scriptRF = rangeFinder.GetComponent<RangeFinder>();

                if(targetSeeker.transform.tag == "Moveable" && scriptRF.isInRange)
                {
                    //Debug.Log(targetSeeker.transform.name);
                    GameObject moveableObject = GameObject.Find(targetSeeker.transform.name);
                    moveableObject.GetComponent<Renderer>().material = lashedMaterial;

                    MoveableItemPosition = targetSeeker.transform.position;
                    Debug.Log(MoveableItemPosition);
                    targetIsSet = true;
                }
            }
        }
    }

/* 
    Function:   Moves a tagged movable object to the target click location
    Invariants: Click location must be a surface on the screen
*/
    void LashShoot()
    {
        if(lashShootController % 2 == 0)
        {
            lashShootController++;
            RaycastHit lashSeeker;

            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out lashSeeker))
            {
                //Calculate direction vector
                Vector3 directionVector = (lashSeeker.point - MoveableItemPosition).normalized;

                //Obtain the script of the moveable object being lashed
                GameObject moveableObject = GameObject.Find(targetSeeker.transform.name);
                MoveableCubeGravity scriptMCG = moveableObject.GetComponent<MoveableCubeGravity>();
                
                //Change material back to unlashed material
                moveableObject.GetComponent<Renderer>().material = unlashedMaterial;

                //Set the gravity equal to where the player clicked, and set anchoring gravity
                //to pull the object towards the surface it has hit. 
                scriptMCG.gravityDirection = directionVector;
                scriptMCG.newGravityDirection = -lashSeeker.normal;

            }
        }
    }
}


