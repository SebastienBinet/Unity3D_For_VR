using UnityEngine;
using System.Collections;

//Usage: Drop this to a GameObject

[System.Serializable]
public class sbinetFpsAnalystic : MonoBehaviour {

    private int m_qtyOfFramesToIgnoreAtStart = 100;
    private int m_qtyBins = 1000;
    private float m_deltaTime;
    [SerializeField]
    private int[] m_qtyFrameThisNbrMs;
    [SerializeField]
    private int m_qtyFameCounted;

    // Use this for initialization
    void Start () {
        m_qtyFrameThisNbrMs = new int[m_qtyBins];
    }
	
	// Update is called once per frame
	void Update () {
        if (m_qtyOfFramesToIgnoreAtStart == 0)
        {
            m_deltaTime = Time.deltaTime;
            if (m_deltaTime > 0.001)
            {
                int binMsThisFrame = (int)(m_deltaTime * 1000);
                // all duration too longs are accumalated in top bin.
                binMsThisFrame = Mathf.Min(binMsThisFrame, (m_qtyBins - 1));
                m_qtyFrameThisNbrMs[binMsThisFrame]++;
                m_qtyFameCounted++;
            }
        }
        else
        {
            --m_qtyOfFramesToIgnoreAtStart;
        }
    }

    void OnGUI()
    {
        OnGUIPercentOver10ms();
        OnGUIThisFrame();
        OnGUIAverage();
        OnGUI_00_01_percent();
        OnGUI_00_10_percent();
        OnGUI_01_00_percent();
        OnGUI_10_00_percent();
    }

    void OnGUIThisFrame()
    {
        //int w = Screen.width;
        int h = Screen.height;
        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(0, 3*h/20, 0, 0);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h / 25;
		style.normal.textColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        //float msec = m_deltaTime * 1000.0f;
        //float fps = 1.0f / m_deltaTime;
        //string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        string text = getCurrentFrameInfo();
        GUI.Label(rect, text, style);
    }

    void OnGUIAverage()
    {
        int h = Screen.height;
        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(0, 4*h/20, 0, 0);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h / 25;
		style.normal.textColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        string text = getAverageFrameInfo();
        GUI.Label(rect, text, style);
    }

    void OnGUIPercentOver10ms()
    {
        int h = Screen.height;
        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(0, 0 * h / 20, 0, 0);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h / 25;
		style.normal.textColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        string text = getPercentOver10ms();
        GUI.Label(rect, text, style);
    }
    void OnGUI_00_01_percent()
    {
        int h = Screen.height;
        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(0, 5 * h / 20, 0, 0);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h / 25;
		style.normal.textColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        string text = getPercentOfFrameOverThresholdInfo(00.01f);
        GUI.Label(rect, text, style);
    }
    void OnGUI_00_10_percent()
    {
        int h = Screen.height;
        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(0, 6 * h / 20, 0, 0);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h / 25;
		style.normal.textColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        string text = getPercentOfFrameOverThresholdInfo(00.1f);
        GUI.Label(rect, text, style);
    }
    void OnGUI_01_00_percent()
    {
        int h = Screen.height;
        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(0, 7 * h / 20, 0, 0);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h / 25;
		style.normal.textColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        string text = getPercentOfFrameOverThresholdInfo(01.0f);
        GUI.Label(rect, text, style);
    }
    void OnGUI_10_00_percent()
    {
        int h = Screen.height;
        GUIStyle style = new GUIStyle();
        Rect rect = new Rect(0, 8 * h / 20, 0, 0);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h / 25;
		style.normal.textColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        string text = getPercentOfFrameOverThresholdInfo(10.0f);
        GUI.Label(rect, text, style);
    }

    string getCurrentFrameInfo()
    {
        float msec = m_deltaTime * 1000.0f;
        float fps = 1000.0f / msec;
        string text = string.Format("This frame: {0:00.0} ms ({1:0.} fps)", msec, fps);
        return text;
    }

    string getAverageFrameInfo()
    {
        int total = 0;

        for (int i = 0; i < m_qtyBins; i ++)
        {
            total += m_qtyFrameThisNbrMs[i] * i ;
        }
        
        float msec = 1.0f * total / m_qtyFameCounted;
        float fps = Mathf.Min( 1000.0f / msec, 1000.0f);
        string text = string.Format("Average since start: {0:00.} ms ({1:0.} fps)", msec, fps);
        return text;
    }

    string getPercentOver10ms()
    {
        int qtyFramesAccumulated = 0;
        for (int i = 0; i < 10; i++)
        {
            qtyFramesAccumulated += m_qtyFrameThisNbrMs[i];
        }
        float percent = 100.0f * (1.0f - 1.0f * qtyFramesAccumulated / m_qtyFameCounted);
        string text = string.Format("{0:0.0} % of frames took more than 10 ms (100 fps) -- Goal: <= 0.1%", percent);
        return text;
    }

    string getPercentOfFrameOverThresholdInfo(float inPercent)
    {
        int threshold = (int)((inPercent / 100) * m_qtyFameCounted);
        int qtyFramesAccumulated = 0;
        int binWhereThresholdWasCrossed = 1;
        for (int i = m_qtyBins - 1; i > 0; --i)
        {
            qtyFramesAccumulated += m_qtyFrameThisNbrMs[i];
            if (qtyFramesAccumulated > threshold)
            {
                binWhereThresholdWasCrossed = i;
                break;
            }
        }
        float msec = 1.0f * binWhereThresholdWasCrossed;
        float fps = 1000.0f / msec;
        string text = string.Format("{0:0.00}% of frames took more than {1:00.} ms ({2:0.} fps)", inPercent, msec, fps);
        return text;
    }
}
