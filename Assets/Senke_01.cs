using UnityEngine;
using System.Collections;

public class Senke_01 : MonoBehaviour
{

    public GameObject Quelle_01_Senke_01;
    //public GameObject Quelle_02_Senke_01;
    public GameObject Senke_02;
    public GameObject Senke_03;
    bool active;

    // Use this for initialization
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Renderer rend = GetComponent<Renderer>();
        Renderer rendQ1S1 = Quelle_01_Senke_01.GetComponent<Renderer>();
        //Renderer rendQ2S1 = Quelle_02_Senke_01.GetComponent<Renderer>();
        //rend2.enabled = true;
        //rend3.enabled = true;
        if (!active)
        {
            rend.material.color = new Color(0, 255, 0);
            rendQ1S1.material.color = new Color(255, 0, 0);
            //rendQ2S1.material.color = new Color(255, 0, 0);
            active = true;
        }
        else if (active)
        {
            rend.material.color = Color.black;
            rendQ1S1.material.color = Color.black;
            //rendQ2S1.material.color = Color.black;
            active = false;
        }
    }
}
