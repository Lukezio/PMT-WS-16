using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventare : MonoBehaviour {

	public int breiteQuelleInventar;
	public int hoeheQuelleInventar;
	public int breiteTransportmittelInventar;
	public int hoeheTransportmittelInventar;
	public GUISkin skin;
	public List<Rohstoff> lagerInventar = new List<Rohstoff> ();
	public List<Rohstoff> transportmittelInventar = new List<Rohstoff> ();
	private List<Rohstoff> slotsQuelle = new List<Rohstoff> ();
	private List<Rohstoff> slotsTransportmittel = new List<Rohstoff> ();
	private RohstoffListe rohstoffListe;
	private bool istSichtbar = false;
	private float lastTime;
	private const float LANGER_KLICK = 0.5f;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < breiteQuelleInventar * hoeheQuelleInventar; i++) {
			slotsQuelle.Add (new Rohstoff());
			lagerInventar.Add (new Rohstoff ());
		}

		for(int i = 0; i < breiteTransportmittelInventar*hoeheTransportmittelInventar; i++) {
			slotsTransportmittel.Add (new Rohstoff());
			transportmittelInventar.Add (new Rohstoff());
		}
		print (transportmittelInventar.Count);

		rohstoffListe = GameObject.FindGameObjectWithTag ("Rohstoff Liste").GetComponent<RohstoffListe>();

		RohstoffQuelleHinzufuegen (0);
		RohstoffQuelleHinzufuegen (1);
		RohstoffQuelleHinzufuegen (2);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {
		lastTime = Time.time;
	}

	void OnMouseUp() {
		if (Time.time - lastTime >= LANGER_KLICK) {
			istSichtbar = !istSichtbar;
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
		ZeigeQuellenInventar (e);
		ZeigeTransportmittelInventar (e);
	}

	void ZeigeQuellenInventar(Event e) {
		int i = 0;
		for(int x = 0; x < breiteQuelleInventar; x++) {
			for(int y = 0; y < hoeheQuelleInventar; y++) {
				Rect slotRect = new Rect (x * 50, y*50, 50, 50);
				GUI.Box (new Rect(x * 50, y * 50, 50, 50), "", skin.GetStyle("Slot"));
				slotsQuelle [i] = lagerInventar [i];
				if(slotsQuelle[i].name != null) {
					GUI.DrawTexture (slotRect, slotsQuelle[i].aussehen);
					if(slotRect.Contains(e.mousePosition)) {
						if(e.button == 0 && e.type == EventType.mouseDown) {
							Rohstoff ausgewaehlterRohstoff = slotsQuelle [i];
							RohstoffVonQuelleEntfernen (ausgewaehlterRohstoff.id);
							RohstoffTransportmittelHinzufuegen (ausgewaehlterRohstoff.id);
						}
					}
				}
				i++;
			}
		}
	}

	void RohstoffQuelleHinzufuegen(int itemID) {
		for(int i = 0; i < lagerInventar.Count; i++) {
			if(lagerInventar[i].name == null) {

				for(int j = 0; j < rohstoffListe.materialien.Count; j++) {
					if(rohstoffListe.materialien[j].id == itemID) {
						lagerInventar [i] = rohstoffListe.materialien [j];
					}
				}
				break;
			}
		}
	}

	void RohstoffVonQuelleEntfernen(int itemID) {
		for(int i = 0; i < lagerInventar.Count; i++) {
			if(lagerInventar[i].id == itemID) {
				lagerInventar [i] = new Rohstoff ();
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
				Rect slotRect = new Rect (x * 50, y*50 + (hoeheQuelleInventar+2)*50, 50, 50);
				GUI.Box (new Rect(x * 50, y * 50 + (hoeheQuelleInventar + 2)*50, 50, 50), "", skin.GetStyle("Slot"));
				slotsTransportmittel [i] = transportmittelInventar [i];
				if(slotsTransportmittel[i].name != null) {
					GUI.DrawTexture (slotRect, slotsTransportmittel[i].aussehen);
				}
				i++;
			}
		}
	}
}
