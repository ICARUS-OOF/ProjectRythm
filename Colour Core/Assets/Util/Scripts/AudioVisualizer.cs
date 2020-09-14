using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioVisualizer : MonoBehaviour {
	
	public AudioSource MyAudio;
	public Transform[] audioSpectrumObjects;
	[Range(0.5f, 200f)] public float heightMultiplier;
	[Range(64, 8192)] public int numberOfSamples = 1024;
	public FFTWindow fftWindow;
	public float lerpTime = 1;

	private Vector3 newScale;
	
    public bool Beating_X, Beating_Y, Beating_XY;
	
	private float Stimer;
	public float DesactivateAfter;
	
    void Update() {

		float[] spectrum = new float[numberOfSamples];

		MyAudio.GetSpectrumData(spectrum, 0, fftWindow);

		for(int i = 0; i < audioSpectrumObjects.Length; i++)
		{

			float intensity = spectrum[i] * heightMultiplier * 5f;

			if(Beating_X){
			
			float lerpX = Mathf.Lerp(audioSpectrumObjects[i].localScale.x,intensity,lerpTime);
			newScale = new Vector3( lerpX, audioSpectrumObjects[i].localScale.y ,
			audioSpectrumObjects[i].localScale.z);
			
			}
			
			if(Beating_Y){
			
			float lerpY = Mathf.Lerp(audioSpectrumObjects[i].localScale.y,intensity,lerpTime);
			newScale = new Vector3( audioSpectrumObjects[i].localScale.x, lerpY,
			audioSpectrumObjects[i].localScale.z);
			
			}
			
			if(Beating_XY){
			
			float lerpX = Mathf.Lerp(audioSpectrumObjects[i].localScale.x,intensity,lerpTime);
			float lerpY = Mathf.Lerp(audioSpectrumObjects[i].localScale.y,intensity,lerpTime);
			newScale = new Vector3( lerpX, lerpY,
			audioSpectrumObjects[i].localScale.z);
			
			}

			audioSpectrumObjects[i].localScale = newScale;
		}
		
		
		Stimer += Time.deltaTime;
		
	    if( Stimer > DesactivateAfter ){
		    
			gameObject.SetActive(false);
	    }
	}

}
