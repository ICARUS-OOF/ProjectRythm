using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Executer {

    public float StartTime ,EndTime;
	public GameObject[] Objs;

}

public class Manager : MonoBehaviour
{
    public string ManagerName; //Just to organize
	
    private int GoThis;
	
	public static bool GameEnd;
	private bool ExecuteOnce;
	
	public Executer[] TimeExecuter;
	
	void Update(){
		
		if(!GameEnd){
		
		if( GoThis < TimeExecuter.Length ){
		
		    if(!ExecuteOnce){
			
		        if(Clock.BackgroundTimer >= TimeExecuter[GoThis].StartTime && Clock.BackgroundTimer <= TimeExecuter[GoThis].EndTime){
		
		            foreach ( GameObject obj in TimeExecuter[GoThis].Objs ){
		   
		                obj.SetActive(true);
		            }
					
					ExecuteOnce = true;
		        }
			}
			
		    if(Clock.BackgroundTimer > TimeExecuter[GoThis].EndTime){
			
		        GoThis += 1;
				ExecuteOnce = false;
		    }
		}
		
		} 
	}
	
	public void GoP(){
	
	    Application.OpenURL("https://www.patreon.com/UnityNinja");
	}
	
	public void GoSub(){
	
	    Application.OpenURL("https://www.youtube.com/channel/UC-P34s4VUj9i344z-MQcTPA");
	}
	
	public void PlayAgain(){
	
	    Time.timeScale = 1;
		GameEnd = false;
	    Application.LoadLevel("GAME");
	}
}
