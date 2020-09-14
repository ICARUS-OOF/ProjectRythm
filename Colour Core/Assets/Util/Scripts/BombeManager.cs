using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BExecuter {

    public float StartTime ,EndTime;
	public GameObject[] BombeShapes;
}

public class BombeManager : MonoBehaviour
{
    
	public int GoThis;
	private float Timer;
	private float Stimer;

	public float DesactivateAfter;

	public BExecuter[] TimeExecuter;
	
	private bool ExecuteOnce;
	
    void Update()
    {
        if(!Manager.GameEnd){
		
		Timer += Time.deltaTime;
		
		if( GoThis < TimeExecuter.Length ){
		
		    if(!ExecuteOnce){
			
		        if(Timer >= TimeExecuter[GoThis].StartTime && Timer <= TimeExecuter[GoThis].EndTime){
				
				    foreach ( GameObject Bombe in TimeExecuter[GoThis].BombeShapes ){
		   
		                Bombe.GetComponent<Bombes>().enabled = true;
		            }
					
					ExecuteOnce = true;
				}
			}
			
			if(Timer > TimeExecuter[GoThis].EndTime){
			
		        GoThis += 1;
				ExecuteOnce = false;
		    }
		}
		
		Stimer += Time.deltaTime;
		
	    if( Stimer > DesactivateAfter ){
		    
			gameObject.SetActive(false);
	    }
		
		}
    }
}
