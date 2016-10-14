using UnityEngine;
using System.Collections;

public class sbinet_CurrentOzoShot : MonoBehaviour {

    public sbinet_InteractiveItemOzoShot m_InteractiveItemOzoShot;
    public sbinetCreateMarkersWhenAtThisPosition m_sbinetCreateMarkersWhenAtThisPosition;

    // Use this for initialization
    void Start () {
        //m_InteractiveItemOzoShot.setupAsCurrentPosition();
        if (m_sbinetCreateMarkersWhenAtThisPosition)
        {
            m_sbinetCreateMarkersWhenAtThisPosition.setupAsCurrentPosition();
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
