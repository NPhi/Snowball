using UnityEngine;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class HealthBossScript : MonoBehaviour
{
	/// <summary>
	/// Total hitpoints
	/// </summary>
	public int hp = 1;
	private float maxHp;
	/// <summary>
	/// Enemy or player?
	/// </summary>
	public bool isEnemy = true;
	public GameObject healthBar;

	void Start(){
		maxHp = hp;
		SetHealthBar(hp/hp);
	}

	/// <summary>
	/// Inflicts damage and check if the object should be destroyed
	/// </summary>
	/// <param name="damageCount"></param>
	public void Damage(int damageCount)
	{
		hp -= damageCount;

		float calHealth = hp / maxHp;
	
		SetHealthBar(calHealth);
		if (hp <= 0)
		{
			// Explosion!
			//SpecialEffectsHelper.Instance.Explosion(transform.position);
			//SoundEffectsHelper.Instance.MakeExplosionSound();

			// Dead!
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage);

				// Destroy the shot
				Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}
	}

	public void SetHealthBar(float myHealth){
		healthBar.transform.localScale = new Vector3(myHealth,healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}

}