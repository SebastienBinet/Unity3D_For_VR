using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {

    public float m_MoveDuration = 1.0f;
    public Transform m_TransformTargetField;
    public Transform m_PrivTransformPrevious;
    public Transform m_PrivTransformTarget;


    public float m_PrivRatioPrevious = -10.0f;
    public float m_PrivRatioTarget = -10.0f;
    public Shader m_PrivShader;
    public Renderer m_PrivRenderer;

    // Use this for initialization
    void Start () {
        // m_CurrentCameraTransform = GetComponent<>().transform;
        //m_StartPosition = m_TransformItem.position;
        //StartCoroutine(FadeOut3D(m_TransformTarget, 0.0f, true, 10.0f));

        //m_Shader = Shader.Find("Unlit/Texture");
        //m_Renderer = GetComponent<Renderer>();
        //m_Renderer.material.shader = m_Shader;
    }

    // Update is called once per frame
    void Update() {
        // Trigger
        if (Input.GetKeyDown("1"))
        {
            GameObject go = GameObject.Find("360VideoAsset_Shot_000");
            m_TransformTargetField = (go ? go.transform : null);
        }
        if (Input.GetKeyDown("2"))
        {
            GameObject go = GameObject.Find("360VideoAsset_Shot_002");
            m_TransformTargetField = (go ? go.transform : null);
        }
        if (m_TransformTargetField != m_PrivTransformTarget)
        {
            // Handle case where we are still in a transition from a to B and we now want to go to C
            if (m_PrivTransformPrevious)
            {
                Transform currentSkyBoxTransform = m_PrivTransformPrevious.Find("SkyBox");
                currentSkyBoxTransform.gameObject.SetActive(false);
            }

            m_PrivTransformPrevious = m_PrivTransformTarget;
            m_PrivTransformTarget = m_TransformTargetField;

            //if (m_PrivTransformPrevious)
            //{
            //    // Set Shader to "Standard-Fade" since we want to fade out this skybox 
            //    Transform currentSkyBoxTransform = m_PrivTransformPrevious.Find("SkyBox");
            //    Shader currentSkyBoxShader = Shader.Find("Standard");
            //    m_PrivRenderer = currentSkyBoxTransform.GetComponent<Renderer>();
            //    m_PrivRenderer.material.shader = currentSkyBoxShader;

            //    m_PrivRenderer.material.EnableKeyword("_ALPHABLEND_ON"); // "Standard-Fade"
            //    // Set Opaque visible
            //    var currentSkyBoxMaterial = currentSkyBoxTransform.GetComponent<Renderer>().material;
            //    currentSkyBoxMaterial.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            //}

            if (m_PrivTransformPrevious)
            {
                // Disable 
                Transform currentSkyBoxTransform = m_PrivTransformPrevious.Find("SkyBox");
                currentSkyBoxTransform.gameObject.SetActive(false);
            }

            if (m_PrivTransformTarget)
            {
                // Display opaque the target skybox.
                Transform targetSkyBoxTransform = m_PrivTransformTarget.Find("SkyBox");
                targetSkyBoxTransform.gameObject.SetActive(true);
                // Set Shader to "Unlit/Texture" since it is ok that the farter skybox is all opaque 
                Shader targetSkyBoxShader = Shader.Find("Unlit/Texture");
                m_PrivRenderer = targetSkyBoxTransform.GetComponent<Renderer>();
                m_PrivRenderer.material.shader = targetSkyBoxShader;
                // Set Transparent visible
                var targetSkyBoxMaterial = targetSkyBoxTransform.GetComponent<Renderer>().material;
                targetSkyBoxMaterial.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }

            //m_TransformPrevious = m_TransformTarget;
            //m_TransformTarget = m_TransformTargetField;
            //// Set target fade to 0, so we will fade-in
            //Transform targetSkyBoxTransform = m_TransformTarget.Find("SkyBox");
            //targetSkyBoxTransform.gameObject.SetActive(true);
            //var targetSkyBoxMaterial = targetSkyBoxTransform.GetComponent<Renderer>().material;
            //var targetColor = targetSkyBoxMaterial.color;
            //m_RatioTarget = 0.0f;
            //targetSkyBoxMaterial.color = new Color(targetColor.r, targetColor.g, targetColor.b, m_RatioTarget);

        } // end of trigger

        if (m_PrivTransformPrevious)
        {
            // Fade-out current skybox
            Transform previousSkyBoxTransform = m_PrivTransformPrevious.Find("SkyBox");
            var previousSkyBoxMaterial = previousSkyBoxTransform.GetComponent<Renderer>().material;
            var prevColor = previousSkyBoxMaterial.color;
            m_PrivRatioPrevious = Mathf.Max(prevColor.a - (Time.deltaTime / 10.0f), 0.0f);
            previousSkyBoxMaterial.color = new Color(prevColor.r, prevColor.g, prevColor.b, m_PrivRatioPrevious);
        }

        if (m_PrivTransformTarget)
        {
            // Move towards the target position.
            transform.position = Vector3.MoveTowards(transform.position, m_PrivTransformTarget.position, Time.deltaTime * 2 / m_MoveDuration);

            //// Fade-in target skybox
            //Transform targetSkyBoxTransform = m_TransformTarget.Find("SkyBox");
            //targetSkyBoxTransform.gameObject.SetActive(true);
            //var targetSkyBoxMaterial = targetSkyBoxTransform.GetComponent<Renderer>().material;
            //var targetColor = targetSkyBoxMaterial.color;
            //m_RatioTarget = Mathf.Min(targetColor.a + (Time.deltaTime / m_MoveDuration), 1.0f);
            //targetSkyBoxMaterial.color = new Color(targetColor.r, targetColor.g, targetColor.b, m_RatioTarget);
        }
    }

}
