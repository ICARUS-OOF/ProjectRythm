using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombes : MonoBehaviour
{
    public GameObject Dot, Parent;
    public GameObject[] SpawnPos;
	
	public float Speed = 6f, boundary_xMin, boundary_xMax;
	
	public bool LeftMovement;
	private bool GoLeft, Once;
	
	private Vector3 Movement;
	
    void Update(){

	    if(!LeftMovement){
		
		    //boundary_xMin = 0f;
		    //boundary_xMax = Screen.width/2f;
				
		    if(!GoLeft){
		        Movement = Vector3.right * Speed;
			
			} else {
		        Movement = Vector3.left * Speed;
			}
			
			if(transform.position.x >= boundary_xMax && !Once){
		
		    for(var i = 0; i < SpawnPos.Length; i++){
		
		    GameObject dot = Instantiate(Dot, SpawnPos[i].transform.position, SpawnPos[i].transform.rotation);
  	    	dot.transform.SetParent(Parent.transform, true);
	        }
		
		    Invoke("MoveAfterExplode", 0.3f);
			
			Once = true;
		    } 
		
		} else {
		
			//boundary_xMin = Screen.width/2f;
		    //boundary_xMax = Screen.width;
				
		    if(!GoLeft){
		        Movement = Vector3.left * Speed;
			
			} else {
		        Movement = Vector3.right * Speed;
			}
			
			if(transform.position.x <= boundary_xMin && !Once){
		
		    for(var i = 0; i < SpawnPos.Length; i++){
		
		    GameObject dot = Instantiate(Dot, SpawnPos[i].transform.position, SpawnPos[i].transform.rotation);
  	    	dot.transform.SetParent(Parent.transform, true);
	        }
		
		    Invoke("MoveAfterExplode", 0.3f);
			
			Once = true;
		    } 
		}
		
		transform.position += Movement;
		transform.position = new Vector3(Mathf.Clamp (transform.position.x, boundary_xMin, boundary_xMax),
		transform.position.y);
		
		
	}
	
	void MoveAfterExplode(){
	
		if(!GoLeft){
		    GoLeft = true;
		} else {
		    GoLeft = false;
		}
	}
}
