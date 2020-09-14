using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

	[Range(200f, 500f)] [SerializeField] private float MoveSpeed = 200f;
	
	public float boundary_xMin, boundary_xMax, boundary_yMin, boundary_yMax;
	
	public GameObject PLAY_AGAIN;
	
	public GameObject[] HeroLife;
	private int LifeGone;
	
	private float dashSpeed = 800;

	private bool Dash;
	
	private Rigidbody2D rb;
	private BoxCollider2D bc;
	private Animator anim;
	
	void Start () {
	
	    rb = GetComponent<Rigidbody2D>();
		bc = GetComponent<BoxCollider2D>();
		anim = GetComponent<Animator>();
		
		boundary_xMin = 20f;
		boundary_xMax = Screen.width - 20f;
		boundary_yMin = 20f;
		boundary_yMax = Screen.height - 20f;
	}
	
	void FixedUpdate(){
	
	    float MoveHorizontal = Input.GetAxis("Horizontal");
		float MoveVertical = Input.GetAxis("Vertical");
	    float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
				
		Vector3 Movement = new Vector3(MoveHorizontal, MoveVertical, 0f);
		transform.position += Movement * Time.deltaTime * MoveSpeed;

		transform.position = new Vector3(Mathf.Clamp (transform.position.x, boundary_xMin, boundary_xMax),
		Mathf.Clamp (transform.position.y, boundary_yMin, boundary_yMax));
		
		if(Input.GetMouseButtonDown(0)){
		
		    if(!Dash){
		
		        if(xRaw != 0 || yRaw != 0){
				
				   bc.enabled = false;
                   StartCoroutine (DashNow(xRaw, yRaw));
				   
				}
		    }
		}
		
		if(LifeGone >= 4){
		
		    PLAY_AGAIN.SetActive(true);
			Manager.GameEnd = true;
			Time.timeScale = 0;
		}
	}
	
	IEnumerator DashNow(float x, float y){
       
        Dash = true;
		
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2(x, y);

		dashSpeed = 800;
        rb.velocity += dir.normalized * dashSpeed;
		
        yield return new WaitForSeconds(.07f);
		
        dashSpeed = 0;
		rb.velocity = dir.normalized * dashSpeed;
		
		Dash = false;
		bc.enabled = true;
    }
	
	void OnTriggerEnter2D(Collider2D col){
	   
   	    if (col.gameObject.tag =="Block"){
		
		    if(LifeGone < 4){
		    
			anim.SetBool("Revive", true);
  			bc.enabled = false;
			LifeGone += 1;
			HeroLife[LifeGone].SetActive(true);
			Invoke("Revive",1.5f);
			
	        Debug.Log("X_X DEAD X_X");
			
			} 
	    }
	}

	void Revive(){
	  
	    anim.SetBool("Revive", false);
	    bc.enabled = true;
	}
}