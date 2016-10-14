using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

//namespace VRStandardAssets.Examples
//{

    public class sbinet_InteractiveItemOzoShot : MonoBehaviour
    {

    //[SerializeField] private VRInteractiveItem m_InteractiveItem;
    public bool m_IsCurrentSkybox = false; // TBD: make private with get/set

    public void setupAsCurrentPosition()
    {
        VRInteractiveItem interactiveItem = gameObject.GetComponent<VRInteractiveItem>();
        interactiveItem.OnOver -= HandleOver;
        interactiveItem.OnOut -= HandleOut;
        interactiveItem.OnClick -= HandleClick;
        interactiveItem.OnDoubleClick -= HandleDoubleClick;
    }

    public void setAsActiveMarker()
    {
        VRInteractiveItem interactiveItem = gameObject.GetComponent<VRInteractiveItem>();
        interactiveItem.OnOver -= HandleOver;
        interactiveItem.OnOut -= HandleOut;
        interactiveItem.OnClick -= HandleClick;
        interactiveItem.OnDoubleClick -= HandleDoubleClick;
        interactiveItem.OnOver += HandleOver;
        interactiveItem.OnOut += HandleOut;
        interactiveItem.OnClick += HandleClick;
        interactiveItem.OnDoubleClick += HandleDoubleClick;
    }

    private void OnEnable()
        {
            //if (!m_IsCurrentSkybox)
            //{
            //    VRInteractiveItem interactiveItem = gameObject.GetComponent<VRInteractiveItem>();
            //    interactiveItem.OnOver += HandleOver;
            //    interactiveItem.OnOut += HandleOut;
            //    interactiveItem.OnClick += HandleClick;
            //    interactiveItem.OnDoubleClick += HandleDoubleClick;
            //}
        }


    private void OnDisable()
    {
        //if (!m_IsCurrentSkybox)
        //{
        //    VRInteractiveItem interactiveItem = gameObject.GetComponent<VRInteractiveItem>();
        //    interactiveItem.OnOver -= HandleOver;
        //    interactiveItem.OnOut -= HandleOut;
        //    interactiveItem.OnClick -= HandleClick;
        //    interactiveItem.OnDoubleClick -= HandleDoubleClick;
        //}
    }

    //Handle the Over event
    private void HandleOver()
    {
        Debug.Log("Show over state");
        transform.localScale = new Vector3(0.15f, 0.2f, 0.15f);
    }


    //Handle the Out event
    private void HandleOut()
    {
        Debug.Log("Show out state");
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }


    //Handle the Click event
    private void HandleClick()
    {
        Debug.Log("Show click state");
        GameObject go = GameObject.Find("HomeVisitor");
        // TBD: Replace by a way to make the move animation
        go.transform.position = transform.position;

        // TBD: replace by a fade-out of current sphere
        GameObject currentSphere = go.GetComponent<sbinet_CurrentOzoShot>().m_InteractiveItemOzoShot.gameObject;
        currentSphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        go.GetComponent<sbinet_CurrentOzoShot>().m_InteractiveItemOzoShot.gameObject.SetActive(false);
        currentSphere.GetComponent<sbinetCreateMarkersWhenAtThisPosition>().removeAsCurrentPosition();

        // TBD: replace by a fade-in of new sphere
        GameObject thisGameObject = gameObject;
        go.GetComponent<sbinet_CurrentOzoShot>().m_InteractiveItemOzoShot = thisGameObject.GetComponent<sbinet_InteractiveItemOzoShot>();
        thisGameObject.GetComponent<sbinetCreateMarkersWhenAtThisPosition>().setupAsCurrentPosition();
    }


    //Handle the DoubleClick event
    private void HandleDoubleClick()
        {
            Debug.Log("Show double click");
        }
    }

//}