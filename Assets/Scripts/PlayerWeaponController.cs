using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {
	public GameObject playerHand;
	public GameObject EquippedWeapon { get; set; }

	IWeapon equppedWeapon;

	CharacterStats characterStats;

	private void Start()
	{
		characterStats = GetComponent<CharacterStats>();
	}

	public void EquipWeapon(Item itemToEquip)
	{
		if (EquippedWeapon != null)
		{
			characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
			Destroy(playerHand.transform.GetChild(0).gameObject);
		}

		EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), 
			playerHand.transform.position, playerHand.transform.rotation);

		equppedWeapon = EquippedWeapon.GetComponent<IWeapon>();
		equppedWeapon.Stats = itemToEquip.Stats;
		EquippedWeapon.transform.SetParent(playerHand.transform);
		characterStats.AddStatBonus(itemToEquip.Stats);
		Debug.Log(equppedWeapon.Stats[0].BaseValue);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.X))
		{
			PerformWeaponAttack();
		}
	}

	public void PerformWeaponAttack()
	{
		equppedWeapon.PerformAttack();
	}
}
