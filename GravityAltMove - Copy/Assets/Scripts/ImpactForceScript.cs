using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ImpactForceScript : MonoBehaviour
{

	public float breakPoint = 20f;

    // Start is called before the first frame update
    void OnCollisionEnter (Collision col)
    {
    	Debug.Log("Impulse is: " + col.impulse);

        if(Mathf.Abs(col.impulse.x) >= breakPoint || Mathf.Abs(col.impulse.y) >= breakPoint || Mathf.Abs(col.impulse.z) >= breakPoint)
        {	
        	Debug.Log("Broken");
        	Destroy(gameObject);
        }
    }


}
