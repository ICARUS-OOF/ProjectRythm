using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    private float Stimer;
	public float DesactivateAfter;
	
    void Update()
    {
        Stimer += Time.deltaTime;
		
	    if( Stimer > DesactivateAfter ){
		    
			gameObject.SetActive(false);
	    }
    }
}
