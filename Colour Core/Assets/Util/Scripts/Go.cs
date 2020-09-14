using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go : MonoBehaviour
{
    public float Speed;
	
    void Update()
    {
       transform.Translate(Vector3.up * Time.deltaTime * Speed);
    }
	
	void OnTriggerEnter2D(Collider2D col){
	   if(col.gameObject.tag =="Wall"){
	      Destroy(gameObject);
	   }
	}
}
