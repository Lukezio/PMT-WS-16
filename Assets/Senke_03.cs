using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Senke_03 : MonoBehaviour
{

	public int breiteSenkeInventar;
	public int hoeheSenkeInventar;
	public int breiteTransportmittelInventar;
	public int hoeheTransportmittelInventar;
	public GUISkin skin;
	public List<Rohstoff> lagerInventar = new List<Rohstoff> ();
	public List<Rohstoff> transportmittelInventar = new List<Rohstoff> ();
	private List<Rohstoff> slotsSenke = new List<Rohstoff> ();
	private List<Rohstoff> slotsTransportmittel = new List<Rohstoff> ();
	private RohstoffListe rohstoffListe;
	private bool istSichtbar = false;
	private float lastTime;
	private const float LANGER_KLICK = 0.5f;

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

	void OnMouseDown() {
		lastTime = Time.time;
	}

	void OnMouseUp() {
		
			if (Time.time - lastTime >= LANGER_KLICK) {
				istSichtbar = !istSichtbar;
			print ("stimmt genau so");
			} else {

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
}
