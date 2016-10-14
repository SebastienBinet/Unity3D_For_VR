using UnityEngine;
using System.Collections;

public class MyPlayScript : MonoBehaviour {

	void Start () {
		MovieTexture movTexture = GetComponent<Renderer>().material.mainTexture as MovieTexture;
		movTexture.loop = true;
		movTexture.Play();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

