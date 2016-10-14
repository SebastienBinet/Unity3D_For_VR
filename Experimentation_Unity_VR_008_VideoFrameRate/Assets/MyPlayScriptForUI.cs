using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyPlayScriptForUI : MonoBehaviour {

    public MovieTexture movTexture;

    void Start () {
		GetComponent<RawImage>().texture = movTexture as MovieTexture;
		movTexture.loop = true;
		movTexture.Play();
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space))
        {
            if (movTexture.isPlaying)
            {
                movTexture.Pause();
            } else
            {
                movTexture.Play();
            }
        }
	}
}

