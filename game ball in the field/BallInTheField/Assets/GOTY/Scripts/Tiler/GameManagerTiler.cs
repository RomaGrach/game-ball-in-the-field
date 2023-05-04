using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManagerTiler : MonoBehaviour
{
    [SerializeField] float ttime;
    [SerializeField] GameObject PLight1;
    [SerializeField] GameObject PLight2;
    [SerializeField] GameObject SLight;
    [SerializeField] GameObject Screen;
    [SerializeField] Material MScreen1;
    [SerializeField] Material MScreen2;
    [SerializeField] Material MScreen3;
    [SerializeField] Material MScreen4;
    [SerializeField] Material MScreen5;
    [SerializeField] Material SScreen;
    [SerializeField] Material RED;
    [SerializeField] Material BLUE;
    [SerializeField] Material GREEN;
    [SerializeField] Material DEFAULT;
    [SerializeField] int TileScore = 0;
    [SerializeField] float StartInterval = 5;
    [SerializeField] float StartTime = 5;  
    public bool RandomisedIntervals = true;
    public float Interval = 0;
    public float T = 0;
    public float oldT = 0;
    public float counter;
    private bool Flag = true;
    private bool Flag2 = true;
    [SerializeField] GameObject Tiles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ttime = Time.fixedTime;
        if (ttime < StartTime) { 
            if (ttime > 0.2f*StartTime) PLight1.SetActive(true);
            if (ttime > 0.4f*StartTime) PLight2.SetActive(true);
            if (ttime > 0.6f * StartTime)
            {
                Screen.GetComponent<MeshRenderer>().material = SScreen;
                SLight.SetActive(true);
            }
            T = StartInterval;
        }
        else
        {
            if (ttime > 1.6f*StartTime && RandomisedIntervals && T == 0f) Interval = Random.Range(0.5f * StartInterval, 1.1f * StartInterval);
            else Interval = StartInterval;
            T += 0.02f;
            if (T >= Interval && Flag)
            {
                counter = Mathf.Round(Mathf.Abs(Interval - (T - Interval)));
                if (counter == 5) Screen.GetComponent<MeshRenderer>().material = MScreen5;

                if (counter == 4) Screen.GetComponent<MeshRenderer>().material = MScreen4;

                if (counter == 3) Screen.GetComponent<MeshRenderer>().material = MScreen3;

                if (counter == 2) Screen.GetComponent<MeshRenderer>().material = MScreen2;

                if (counter == 1) Screen.GetComponent<MeshRenderer>().material = MScreen1;

                if (counter == 0) Flag = false;
            }
            else if(!Flag && Flag2)
            {
                string colorLane = RandomColorGen();
                MeshRenderer[] TileArray = Tiles.GetComponentsInChildren<MeshRenderer>();
                if (colorLane[0] == 'r') Screen.GetComponent<MeshRenderer>().material = RED;
                if (colorLane[0] == 'b') Screen.GetComponent<MeshRenderer>().material = BLUE;
                if (colorLane[0] == 'g') Screen.GetComponent<MeshRenderer>().material = GREEN;
                for (int i = 0; i < TileArray.Length; i++)
                {
                    if (colorLane[i] == 'r') TileArray[i].material = RED;
                    if (colorLane[i] == 'b') TileArray[i].material = BLUE;
                    if (colorLane[i] == 'g') TileArray[i].material = GREEN;
                }
                Flag2 = false;
                oldT = T;
            }
            else if(!Flag && !Flag2 && Mathf.Abs(T - oldT) >= 0.6f*Interval)
            {
                
                MeshRenderer[] TileArray = Tiles.GetComponentsInChildren<MeshRenderer>();
                for (int i = 0; i < TileArray.Length; i++) TileArray[i].material = DEFAULT;
                T = 0f;
                Flag = true;
                Flag2 = true;
            }


        }
    }
    string RandomColorGen(int tileN = 9, string colors = "rbg")
    {
        string colorL = "";
        int r = colors.Length;
        for (int i = 0; i < tileN; i++)
        {
            colorL += colors[Random.Range(0,r)];
        }
        return colorL;
    }
}
