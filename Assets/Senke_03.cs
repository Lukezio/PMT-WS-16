using UnityEngine;
using System.Collections;

public class Senke_03 : MonoBehaviour
{

    public GameObject Quelle_01_Senke_03;
    public GameObject Quelle_02_Senke_03;
    public GameObject Quelle_03_Senke_03;
    bool active;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Renderer rend = GetComponent<Renderer>();
        Renderer rendQ1S3 = Quelle_01_Senke_03.GetComponent<Renderer>();
        Renderer rendQ2S3 = Quelle_02_Senke_03.GetComponent<Renderer>();
        Renderer rendQ3S3 = Quelle_03_Senke_03.GetComponent<Renderer>();
        //rend2.enabled = true;
        //rend3.enabled = true;
        if (!active)
        {
            rend.material.color = new Color(0, 255, 0);
            rendQ1S3.material.color = new Color(255, 0, 0);
            rendQ2S3.material.color = new Color(255, 0, 0);
            rendQ3S3.material.color = new Color(255, 0, 0);
            active = true;
        }
        else if (active)
        {
            rend.material.color = Color.black;
            rendQ1S3.material.color = Color.black;
            rendQ2S3.material.color = Color.black;
            rendQ3S3.material.color = Color.black;
            active = false;
        }
    }
}
