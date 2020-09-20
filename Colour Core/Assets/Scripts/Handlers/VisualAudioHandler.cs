using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ColourCore
{
	namespace Handlers
	{
		public class VisualAudioHandler : MonoBehaviour
		{
			public Transform[] audioSpectrumObjects;
			public float heightMultiplier;
			[Range(64, 8192)] public int numberOfSamples = 1024;
			public FFTWindow fftWindow;
			public float lerpTime = 1;

			private Vector3 newScale;

			public bool Beating_X, Beating_Y, Beating_XY;

			public float ActivateDelay;
			void Start()
			{
				StartCoroutine(OnUpdate());
			}
			IEnumerator OnUpdate()
			{
				for (int i = 0; i < audioSpectrumObjects.Length; i++)
				{
					audioSpectrumObjects[i].gameObject.SetActive(false);
				}

				yield return new WaitForSeconds(ActivateDelay);

				for (int i = 0; i < audioSpectrumObjects.Length; i++)
				{
					audioSpectrumObjects[i].gameObject.SetActive(true);
				}

				while (true)
				{
					float[] spectrum = new float[numberOfSamples];

					if (GameHandler.singleton != null)
					{
						GameHandler.singleton.Music.GetSpectrumData(spectrum, 0, fftWindow);
					} else
					{
						GetComponent<AudioSource>().GetSpectrumData(spectrum, 0, fftWindow);
					}

					for (int i = 0; i < audioSpectrumObjects.Length; i++)
					{

						float intensity = spectrum[i] * heightMultiplier * 5f;

						if (Beating_X)
						{

							float lerpX = Mathf.Lerp(audioSpectrumObjects[i].localScale.x, intensity, lerpTime);
							newScale = new Vector3(lerpX, audioSpectrumObjects[i].localScale.y,
							audioSpectrumObjects[i].localScale.z);

						}

						if (Beating_Y)
						{

							float lerpY = Mathf.Lerp(audioSpectrumObjects[i].localScale.y, intensity, lerpTime);
							newScale = new Vector3(audioSpectrumObjects[i].localScale.x, lerpY,
							audioSpectrumObjects[i].localScale.z);

						}

						if (Beating_XY)
						{

							float lerpX = Mathf.Lerp(audioSpectrumObjects[i].localScale.x, intensity, lerpTime);
							float lerpY = Mathf.Lerp(audioSpectrumObjects[i].localScale.y, intensity, lerpTime);
							newScale = new Vector3(lerpX, lerpY,
							audioSpectrumObjects[i].localScale.z);

						}

						audioSpectrumObjects[i].localScale = newScale;
					}

					//if (Stimer > DesactivateAfter)
					//{
					//	gameObject.SetActive(false);
					//}
					yield return null;
				}
			}
		}
	}
}