using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeFinder : MonoBehaviour
{

	public bool isInRange = false;
	public Material inRangeMaterial;
	public Material notInRangeMaterial;

	private float range;
	private Material lastMaterial;

	GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        GetComponent<Renderer>().material = notInRangeMaterial;
    }


    void Update()
    {
        if(inRange())
        {
        	isInRange = true;




        }

        else
        {
        	isInRange = false;

        		
        }

        //Debug.Log("Is In Range is: " + isInRange);
    }

    bool inRange()
    {
    	range = Vector3.Distance(player.transform.position, transform.position);
    	//Debug.Log(range);
    	if(range < 2.0f + transform.localScale.x)
    		return true;

    	else
    		return false;
    }
}
