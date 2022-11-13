using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class TypeWriterEffect : MonoBehaviour {

	public float delay = 0.1f;
	public string fullText;
	public string currentText = "";

	public AudioSource ad;
	// Use this for initialization
	void Start () {
		
	}
	
	public void TypeText(){
		StartCoroutine(ShowText());
	}
	
	IEnumerator ShowText(){
		for(int i = 0; i < fullText.Length+1; i++){
			currentText = fullText.Substring(0,i);
			this.GetComponent<TMP_Text>().text = currentText;
			if(ad != null)
			{
				ad.Play();
			}
			yield return new WaitForSeconds(delay);
		}
	}
}
