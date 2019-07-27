using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraLogic : MonoBehaviour
{
   //Dhannya Mathew credits code by Saili Chola 
    public static CameraLogic instance = null;

    SpriteRenderer camTransistions; // for fade in and out screen

    SpriteRenderer dayNightMask; //for day and night cycle

    public Color startCol,
                 daybreak = new Color(0.91f, 0.77f, 0.38f, 0.2f),
                 midday = new Color(0.7f, 0.92f, 0.94f, 0.2f),
                 afternoon = new Color(0.87f, 0.42f, 0.25f, 0.2f),
                 night = new Color(0.10f, 0.12f, 0.53f, 0.2f),
                 midnight = new Color(0.31f,0.09f,0.67f,0.2f),
                 earlyMorning = new Color (0.5f,0.2f,0.33f,0.2f);

    bool dayOn = false;

    public int dayPhaseCounter = 0;// 0 = neutral, 1 = daybreak, 2 = midday, 3 = afternoon, 4 = night; 

    //splits the day into four phases. note that the below times must equal 1f to work properly.
    public float dbTlim = 0.1f, mdTlim = 0.2f, anTlim = 0.4f, nTlim = 0.2f, mnTlim = 0.1f, emTlim = 0.1f;

    public float dayPhaseTime, dayPhaseTLim, dayPhasePerc;
    public float dayTime, dayTLim = 10f, dayPerc;

    public bool sceneActive;
    public float sceneTimer, sceneTLim = 2f, scenePerc;

    void Awake ()
    {
        camTransistions = GameObject.Find("ScreenMask").GetComponent<SpriteRenderer>();
        dayNightMask = GameObject.Find("DnNMask").GetComponent<SpriteRenderer>();

        //DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        /*daybreak = new Color(0.91f, 0.77f, 0.38f, 0.15f);
        midday = new Color(0.7f, 0.92f, 0.94f, 0.2f);
        afternoon = new Color(0.87f, 0.42f, 0.25f, 0.3f);
        night = new Color(0.10f, 0.03f, 0.47f, 0.3f);
        midnight = new Color(0.31f, 0.09f, 0.67f, 0.2f);
        earlyMorning = new Color(0.78f, 0.12f, 0.41f, 0.2f);*/
        
        SimulateDay();
        
        //dayNightMask.color = Color.black;

    }

    void changeLighting(float length, Color start, Color end)
    {
        dayPhasePerc = dayPhaseTime / dayPhaseTLim;
        dayPhasePerc = dayPhasePerc * dayPhasePerc * dayPhasePerc * (dayPhasePerc * (6f * dayPhasePerc - 15f) + 10f);

        dayNightMask.color = Color.Lerp(start, end, dayPhasePerc);

        if (dayPhaseTime >= dayPhaseTLim)
        {
            dayPhaseCounter++;
            dayPhaseTime = 0f;
            dayPhaseTLim = (length * dayTLim);
        }
    }

    void Update()
    {       

        if (dayOn)
        {
            Timer(ref dayTime, dayTLim);

            dayPerc = dayTime / dayTLim;

            switch (dayPhaseCounter)
            {
                //daybreak transition
                case 1:
                    Timer(ref dayPhaseTime, dayPhaseTLim);
                    changeLighting(mdTlim, startCol, daybreak);  
                    break;
                //midday transition
                case 2:
                    Timer(ref dayPhaseTime, dayPhaseTLim);
                    changeLighting(anTlim, daybreak, midday);
                    break;

                //afternoon transistion
                case 3:
                    Timer(ref dayPhaseTime, dayPhaseTLim);
                    changeLighting(nTlim, midday, afternoon);
                    break;

                //night transition
                case 4:
                    Timer(ref dayPhaseTime, dayPhaseTLim);
                    changeLighting(mnTlim, afternoon, night);
                    break;

                //night transition
                case 5:
                    Timer(ref dayPhaseTime, dayPhaseTLim);
                    changeLighting(emTlim, night, midnight);
                    break;

                case 6:
                    Timer(ref dayPhaseTime, dayPhaseTLim);
                    dayPhasePerc = dayPhaseTime / dayPhaseTLim;
                    dayPhasePerc = dayPhasePerc * dayPhasePerc * dayPhasePerc * (dayPhasePerc * (6f * dayPhasePerc - 15f) + 10f);

                    dayNightMask.color = Color.Lerp(midnight, earlyMorning, dayPhasePerc);

                    if (dayPhaseTime >= dayPhaseTLim)
                    {
                        
                        SimulateDay();
                    }
                    break;
            }
        }

        if (!sceneActive)
        {
            if (sceneTimer <= sceneTLim)
            {
                Timer(ref sceneTimer, sceneTLim);
                scenePerc = sceneTimer / sceneTLim;

                camTransistions.color = Color.Lerp(Color.black,Color.clear,scenePerc);
            }
        }
        else if (sceneActive)
        {
            if (sceneTimer >= 0f)
            {
                RevTimer(ref sceneTimer, sceneTLim);
                scenePerc = (sceneTimer / sceneTLim);

                camTransistions.color = Color.Lerp(Color.black, Color.clear, scenePerc);
            }
        }
    }

    public void TransitionScene ()
    {
        if (sceneActive)
        {
            sceneActive = false;
            //sceneTimer = 0f;
        }
        else
        {
            sceneActive = true;
            //sceneTimer = 0f;
        }
    }


    public void SimulateDay()
    {
        startCol = dayNightMask.color;

        dayPhaseCounter = 1;
        dayTime = 0f;
        dayPhaseTLim = (dbTlim * dayTLim);
        dayPhaseTime = 0f;

        dayOn = true;
        
        
    }

    public void CancelDay()
    {
        dayOn = false;
    }

    public void Timer (ref float time, float timerLim )
    {
        if (time <= timerLim)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = timerLim;
        }
    }

    public void RevTimer(ref float time, float timerLim)
    {
        if (time >= 0f)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = 0f;
        }
    }
}
