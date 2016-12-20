using UnityEngine;
using System.Collections;

public class Senke_02 : MonoBehaviour
{

    public GameObject Quelle_01_Senke_02;
    public GameObject Quelle_02_Senke_02;
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
        Renderer rendQ1S2 = Quelle_01_Senke_02.GetComponent<Renderer>();
        Renderer rendQ2S2 = Quelle_02_Senke_02.GetComponent<Renderer>();
        //rend2.enabled = true;
        //rend3.enabled = true;
        if (!active)
        {
            rend.material.color = new Color(0, 255, 0);
            rendQ1S2.material.color = new Color(255, 0, 0);
            rendQ2S2.material.color = new Color(255, 0, 0);
            active = true;
        }
        else if (active)
        {
            rend.material.color = Color.black;
            rendQ1S2.material.color = Color.black;
            rendQ2S2.material.color = Color.black;
            active = false;
        }
    }
}
