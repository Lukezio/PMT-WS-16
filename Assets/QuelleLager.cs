using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuelleLager : MonoBehaviour {

	public int breite;
	public int hoehe;
	public GUISkin skin;
	public List<Rohstoff> lagerInventar = new List<Rohstoff> ();
	private  List<Rohstoff> slots = new List<Rohstoff> ();
	private RohstoffListe rohstoffListe;
	private bool istSichtbar = false;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < breite * hoehe; i++) {
			slots.Add (new Rohstoff());
			lagerInventar.Add (new Rohstoff ());
		}

		rohstoffListe = GameObject.FindGameObjectWithTag ("Rohstoff Liste").GetComponent<RohstoffListe>();

		RohstoffHinzufuegen (0);
		RohstoffHinzufuegen (1);
		RohstoffHinzufuegen (2);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Lager Inventar")) {
			istSichtbar = !istSichtbar;
		}
	}

	void OnGUI ()
	{
		GUI.skin = skin;
		if(istSichtbar) {
			ZeigeLagerInventar ();
		}
	}

	void ZeigeLagerInventar() {
		int i = 0;
		for(int x = 0; x < breite; x++) {
			for(int y = 0; y < hoehe; y++) {
				Rect slotRect = new Rect (x * 60, y*60, 50, 50);
				GUI.Box (new Rect(x * 60, y * 60, 50, 50), "", skin.GetStyle("Slot"));
				slots [i] = lagerInventar [i];
				if(slots[i].name != null) {
					GUI.DrawTexture (slotRect, slots[i].aussehen);
				}
				i++;
			}
		}
	}

	void RohstoffHinzufuegen(int itemID) {
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

	void EntferneRohstoff(int itemID) {
		for(int i = 0; i < lagerInventar.Count; i++) {
			if(lagerInventar[i].id == itemID) {
				lagerInventar [i] = new Rohstoff ();
				break;
			}
		}
	}
}
