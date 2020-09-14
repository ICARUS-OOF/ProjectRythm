using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public static float BackgroundTimer;
	public Text Background_Timer;
	
	void Start(){
	
	    BackgroundTimer = 0;
	}
	
    void Update(){
	
	    BackgroundTimer += Time.deltaTime;
		DisplayTime();
    }
	
    void DisplayTime(){
	
	    int d = (int)(BackgroundTimer * 100.0f);
        int Bminutes = d / (60 * 100);
        int Bseconds = (d % (60 * 100)) / 100;
        int Bmilseconds = d % 100;
			 
		string niceTime = string.Format("{0:00}:{1:00}:{2:00}", Bminutes, Bseconds, Bmilseconds);
		Background_Timer.text = niceTime;
	
	}
}
