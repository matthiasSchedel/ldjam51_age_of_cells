using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TimerUI;
    [SerializeField] TextMeshProUGUI m_ViruesKilledUI;


    public bool playing;
    private float Timer;
    public int virusesKilled;
    // Start is called before the first frame update
    void Start()
    {
        playing = true;
        virusesKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (playing == true)
        {

            Timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(Timer / 60F);
            int seconds = Mathf.FloorToInt(Timer % 60F);
            int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
            m_TimerUI.text = minutes.ToString("00") + ":" + seconds.ToString("00"); //  ":" + milliseconds.ToString("00");
        }

    }

    public void VirusKilled() {
        virusesKilled += 1;
        m_ViruesKilledUI.text = virusesKilled.ToString();
    }
}
