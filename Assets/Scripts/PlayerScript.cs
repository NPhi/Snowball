using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// 5 - Shooting
		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2"); // For Mac users, ctrl + arrow is a bad idea

		if (shoot)
		{
			WeaponScript weapon = GetComponent<WeaponScript>();

			if (weapon != null && weapon.CanAttack)
			{
				weapon.Attack(false);
				//SoundEffectsHelper.Instance.MakePlayerShotSound();
			}
		}
	}
}
