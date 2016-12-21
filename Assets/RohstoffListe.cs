using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RohstoffListe : MonoBehaviour {

	public List<Rohstoff> materialien = new List<Rohstoff>();

	void Start() 
	{
		int i = 0;
		materialien.Add (new Rohstoff("Holz", i++));
		materialien.Add (new Rohstoff("Nagel", i++));
		materialien.Add (new Rohstoff("Schraube", i++));
	}

}