using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class sbinet_InteractiveItem_Marker_Handling : MonoBehaviour {

    [SerializeField] private float m_MoveDuration = 1.0f;
    [SerializeField] private Material m_NormalMaterial;
    [SerializeField] private Material m_OverMaterial;
    [SerializeField] private Material m_ClickedMaterial;
    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private sbinet_MoveVisitorToHere m_sbinet_MoveVisitorToHere;
    [SerializeField] private Renderer m_Renderer;


    private void Awake()
    {
        m_Renderer.material = m_NormalMaterial;
    }

    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        m_InteractiveItem.OnClick += HandleClick;

    }


    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        m_InteractiveItem.OnClick -= HandleClick;
    }

    //Handle the Over event
    private void HandleOver()
    {
        Debug.Log("Show over state");
        m_Renderer.material = m_OverMaterial;
    }


    //Handle the Out event
    private void HandleOut()
    {
        Debug.Log("Show out state");
        m_Renderer.material = m_NormalMaterial;
    }


    //Handle the Click event
    private void HandleClick()
    {
        Debug.Log("Show click state");
        m_Renderer.material = m_ClickedMaterial;
        if (m_sbinet_MoveVisitorToHere)
        {
            GameObject go = GameObject.Find("HomeVisitor");
            // TBD: Replace by a way to make the move animation  go.transform.position = Vector3.MoveTowards(go.transform.position, m_sbinet_MoveVisitorToHere.transform.position, Time.deltaTime * 2 / m_MoveDuration);
            go.transform.position = m_sbinet_MoveVisitorToHere.transform.position;
            // TBD: replace by a fade-out of current sphere
            Transform thisTransform = transform;
            Transform thisParent = thisTransform.parent;
            Transform thisParentParent = thisParent.parent;
            GameObject thisParentParentGameObject = thisParentParent.gameObject;
            thisParentParentGameObject.SetActive(false);

            // TBD: replace by a fade-in of new sphere
            m_sbinet_MoveVisitorToHere.gameObject.SetActive(true);
            //m_sbinet_MoveVisitorToHere.GetComponentInParent<GameObject>().SetActive(true);
        }

    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
