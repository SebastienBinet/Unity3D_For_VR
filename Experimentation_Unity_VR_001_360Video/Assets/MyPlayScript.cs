using UnityEngine;
using System.Collections;

public class MyPlayScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MovieTexture movTexture = GetComponent<Renderer>().material.mainTexture as MovieTexture;
		movTexture.Play();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

