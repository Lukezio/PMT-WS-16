using UnityEngine;
using System.Collections;

[System.Serializable]
public class Rohstoff {

	public string name;
	public int id;
	public Texture2D aussehen;

	public Rohstoff(string itemName, int itemID) {
		name = itemName;
		id = itemID;
		aussehen = Resources.Load<Texture2D> (itemName);
	}

	public Rohstoff() {
		name = null;
		id = -1;
	}

}
