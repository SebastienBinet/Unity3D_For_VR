using UnityEngine;
using System.Collections;

public class sbinetCreateMarkersWhenAtThisPosition : MonoBehaviour {

    [SerializeField] private sbinet_MoveVisitorToHere[] m_sbinet_MoveVisitorToHere;

    public void removeAsCurrentPosition()
    {
        // Set this object
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        gameObject.SetActive(false);

        // Set other objects
        foreach (var a in m_sbinet_MoveVisitorToHere)
        {
            if (a)
            {
                a.gameObject.SetActive(false);
                a.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
        }
    }

    public void setupAsCurrentPosition()
    {
        // Set this object
        gameObject.SetActive(true);
        transform.localScale = new Vector3(10f, 10f, 10f);
        // No interactivity on the sphere that is the skybox
        GetComponent<sbinet_InteractiveItemOzoShot>().setupAsCurrentPosition();



        // Set other objects
        foreach (var a in m_sbinet_MoveVisitorToHere)
        {
            if (a)
            {
                a.gameObject.SetActive(true);
                a.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                // Enable interactivity on the spheres that are markers
                a.gameObject.GetComponent<sbinet_InteractiveItemOzoShot>().setAsActiveMarker();
            }
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
