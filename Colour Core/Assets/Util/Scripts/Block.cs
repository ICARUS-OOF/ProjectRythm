using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Animator animator;
	
	public GameObject Dot, Parent;
	
	public float Z;
	public float DesactivateAfter;
	public float Dot_SpawnRate = 1f;
    private float Dot_NextSpawn;
	private float Btimer;
	
	public bool Active_Animator, Active_BackAndForth, Active_Rotator, Active_Shooting;
		
    void Start(){
       
	    if(Active_Animator){
		
		    animator = GetComponent<Animator>();
			animator.enabled = true;
		}
		
		if(Active_BackAndForth){
		
		    GetComponent<BackAndForth>().enabled = true;
		}
		
    }
	
	void Update(){
	
	    if(!Manager.GameEnd){
		
	        Btimer += Time.deltaTime;
		
	        if( Btimer > DesactivateAfter ){
		    
			    gameObject.SetActive(false);
	        }
		
	     	if(Active_Rotator){
		
		        transform.Rotate (0,0,Z);
		    }
		
		    if(Active_Shooting){
		
		        if(Time.time > Dot_NextSpawn){
		
		            Dot_NextSpawn = Time.time + Dot_SpawnRate;
		    
		            GameObject dot = Instantiate(Dot, transform.position, transform.rotation);
		       
  			        dot.transform.SetParent(Parent.transform, true);
		        }
		    }
		}
	}
}
