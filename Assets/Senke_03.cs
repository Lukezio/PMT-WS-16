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
	public List<Rohstoff> senkeInventar = new List<Rohstoff> ();
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
	void Start () {
		for(int i = 0; i < breiteSenkeInventar * hoeheSenkeInventar; i++) {
			slotsSenke.Add (new Rohstoff());
			senkeInventar.Add (new Rohstoff ());
		}

		for(int i = 0; i < breiteTransportmittelInventar*hoeheTransportmittelInventar; i++) {
			slotsTransportmittel.Add (new Rohstoff());
			transportmittelInventar.Add (new Rohstoff());
		}

		rohstoffListe = GameObject.FindGameObjectWithTag ("Rohstoff Liste").GetComponent<RohstoffListe>();
		RohstoffTransportmittelHinzufuegen (2);
		RohstoffTransportmittelHinzufuegen (0);
		RohstoffTransportmittelHinzufuegen (1);

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

	void OnGUI ()
	{
		GUI.skin = skin;
		if(istSichtbar) {
			ZeigeInventare ();
		}
	}

	void ZeigeInventare() {
		Event e = Event.current;
		ZeigeTransportmittelInventar (e);
		ZeigeSenkenInventar (e);
	}

	void ZeigeSenkenInventar(Event e) {
		int i = 0;
		for(int x = 0; x < breiteSenkeInventar; x++) {
			for(int y = 0; y < hoeheSenkeInventar; y++) {
				Rect slotRect = new Rect (x * 50, y*50, 50, 50);
				GUI.Box (new Rect(x * 50, y * 50, 50, 50), "", skin.GetStyle("Slot"));
				slotsSenke [i] = senkeInventar [i];
				if(slotsSenke[i].name != null) {
					GUI.DrawTexture (slotRect, slotsSenke[i].aussehen);
				}
				i++;
			}
		}
	}

	void RohstoffSenkeHinzufuegen(int itemID) {
		for(int i = 0; i < senkeInventar.Count; i++) {
			if(senkeInventar[i].name == null) {

				for(int j = 0; j < rohstoffListe.materialien.Count; j++) {
					if(rohstoffListe.materialien[j].id == itemID) {
						senkeInventar [i] = rohstoffListe.materialien [j];
					}
				}
				break;
			}
		}
	}

	void RohstoffVonSenkeEntfernen(int itemID) {
		for(int i = 0; i < senkeInventar.Count; i++) {
			if(senkeInventar[i].id == itemID) {
				senkeInventar [i] = new Rohstoff ();
				break;
			}
		}
	}

	void RohstoffVonTransportmittelEntfernen(int itemID) {
		for(int i = 0; i < transportmittelInventar.Count; i++) {
			if(transportmittelInventar[i].id == itemID) {
				transportmittelInventar [i] = new Rohstoff ();
				break;
			}
		}
	}

	void RohstoffTransportmittelHinzufuegen(int itemID) {
		for(int i = 0; i < transportmittelInventar.Count; i++) {
			if(transportmittelInventar[i].name == null) {
				for(int j = 0; j < rohstoffListe.materialien.Count; j++) {
					if(rohstoffListe.materialien[j].id == itemID) {
						transportmittelInventar [i] = rohstoffListe.materialien [j];
					}
				}
				break;
			}
		}
	}

	void ZeigeTransportmittelInventar(Event e) {
		int i = 0;
		for(int x = 0; x < breiteTransportmittelInventar; x++) {
			for(int y = 0; y < hoeheTransportmittelInventar; y++) {
				Rect slotRect = new Rect (x * 50, y*50 + (hoeheSenkeInventar+2)*50, 50, 50);
				GUI.Box (new Rect(x * 50, y * 50 + (hoeheSenkeInventar + 2)*50, 50, 50), "", skin.GetStyle("Slot"));
				slotsTransportmittel [i] = transportmittelInventar [i];
				if(slotsTransportmittel[i].name != null) {
					GUI.DrawTexture (slotRect, slotsTransportmittel[i].aussehen);
					if(slotRect.Contains(e.mousePosition)) {
						if(e.button == 0 && e.type == EventType.mouseDown) {
							Rohstoff ausgewaehlterRohstoff = slotsTransportmittel [i];
							RohstoffSenkeHinzufuegen (ausgewaehlterRohstoff.id);
							RohstoffVonTransportmittelEntfernen (ausgewaehlterRohstoff.id);
							print ("done");
						}
					}
				}
				i++;
			}
		}
	}
}
