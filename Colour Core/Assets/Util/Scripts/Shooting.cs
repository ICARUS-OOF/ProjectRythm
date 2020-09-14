using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SExecuter {

    public float StartTime ,EndTime;
	public bool Random_Shooting, Spiral_Shooting, Flower_Shooting, Traingle_Shooting, Cool_Shooting;
	public bool GlobelActivation, Enable_BackAndForth, Enable_Rotator;
	public GameObject[] BlockShootingShapes;

}

public class Shooting : MonoBehaviour
{

	private int GoThis;
	private float Timer;
	private float Stimer;

	public float DesactivateAfter;
	
	public SExecuter[] TimeExecuter;
	
	private bool ExecuteOnce;
	
    void Update()
    {
        if(!Manager.GameEnd){
		
			Timer += Time.deltaTime;
		
		    if( GoThis < TimeExecuter.Length ){
		
		        if(!ExecuteOnce){
			
		            if(Timer >= TimeExecuter[GoThis].StartTime && Timer <= TimeExecuter[GoThis].EndTime){
		
		                foreach ( GameObject sr in TimeExecuter[GoThis].BlockShootingShapes ){
		   
		                    if( TimeExecuter[GoThis].Random_Shooting){
							
							    float Rnd_R = Random.Range(10f,40f);
								float Rnd_SR = Random.Range(0.1f,1.5f);
							    sr.GetComponent<Block>().Z = Rnd_R;
								sr.GetComponent<Block>().Dot_SpawnRate = Rnd_SR;
								
								if(TimeExecuter[GoThis].GlobelActivation){
								sr.GetComponent<Block>().Active_BackAndForth = TimeExecuter[GoThis].Enable_BackAndForth;
								sr.GetComponent<Block>().Active_Rotator = TimeExecuter[GoThis].Enable_Rotator;
								}
                            }
							if( TimeExecuter[GoThis].Spiral_Shooting){
							
							    sr.GetComponent<Block>().Z = 2f;
								sr.GetComponent<Block>().Dot_SpawnRate = 0.1f;
								
								if(TimeExecuter[GoThis].GlobelActivation){
								sr.GetComponent<Block>().Active_BackAndForth = TimeExecuter[GoThis].Enable_BackAndForth;
								sr.GetComponent<Block>().Active_Rotator = TimeExecuter[GoThis].Enable_Rotator;
								}
                            }
							if( TimeExecuter[GoThis].Flower_Shooting){
							
							    sr.GetComponent<Block>().Z = 8f;
								sr.GetComponent<Block>().Dot_SpawnRate = 0.2f;
								
								if(TimeExecuter[GoThis].GlobelActivation){
								sr.GetComponent<Block>().Active_BackAndForth = TimeExecuter[GoThis].Enable_BackAndForth;
								sr.GetComponent<Block>().Active_Rotator = TimeExecuter[GoThis].Enable_Rotator;
								}
                            }
							if( TimeExecuter[GoThis].Traingle_Shooting){
							
							    sr.GetComponent<Block>().Z = 200f;
								sr.GetComponent<Block>().Dot_SpawnRate = 0.1f;
								
								if(TimeExecuter[GoThis].GlobelActivation){
								sr.GetComponent<Block>().Active_BackAndForth = TimeExecuter[GoThis].Enable_BackAndForth;
								sr.GetComponent<Block>().Active_Rotator = TimeExecuter[GoThis].Enable_Rotator;
								}
                            }
						
							if( TimeExecuter[GoThis].Cool_Shooting){
							
							    sr.GetComponent<Block>().Z = 1000f;
								sr.GetComponent<Block>().Dot_SpawnRate = 0.05f;
								
								if(TimeExecuter[GoThis].GlobelActivation){
								sr.GetComponent<Block>().Active_BackAndForth = TimeExecuter[GoThis].Enable_BackAndForth;
								sr.GetComponent<Block>().Active_Rotator = TimeExecuter[GoThis].Enable_Rotator;
								}
                            }
							
                            //Add Ur Shooting Shape Here						

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
