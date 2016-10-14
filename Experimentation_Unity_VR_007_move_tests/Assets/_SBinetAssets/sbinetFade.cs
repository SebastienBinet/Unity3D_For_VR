using UnityEngine;
using System.Collections;

public class sbinetFade : MonoBehaviour {
//#if (0)
//    // Use this for initialization
//    void Start () {
//        StartCoroutine(transform.FadeOut3D(0, true, 10));

//    }
	
//	// Update is called once per frame
//	void Update () {
	
//	}

//    // based on http://answers.unity3d.com/questions/992672/fade-gameobject-alpha-with-standard-shader.html
//    public static IEnumerator FadeOut3D(this Transform t, float targetAlpha, bool isVanish, float duration)
//    {
//        //Transform t = transform;
//        Renderer sr = t.GetComponent<Renderer>();
//        float diffAlpha = (targetAlpha - sr.material.color.a);

//        float counter = 0;
//        while (counter < duration)
//        {
//            float alphaAmount = sr.material.color.a + (Time.deltaTime * diffAlpha) / duration;
//            sr.material.color = new Color(sr.material.color.r, sr.material.color.g, sr.material.color.b, alphaAmount);

//            counter += Time.deltaTime;
//            yield return null;
//        }
//        sr.material.color = new Color(sr.material.color.r, sr.material.color.g, sr.material.color.b, targetAlpha);
//        if (isVanish)
//        {
//            sr.transform.gameObject.SetActive(false);
//        }
//    }
//#endif

}

