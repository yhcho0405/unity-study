using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    public Transform weaponHold;
    public Gun startingGun;
    Gun equippedGun;

    void Start() {
        if (startingGun != null) {
            EquipGun(startingGun);
        }
    }

    public void EquipGun(Gun gunToEquip) {
        if (equippedGun != null) {
            Destroy(equippedGun.gameObject);
        }
        // 인스턴스화
        equippedGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;
        // 장착중인 무기의 부모를 player의 weaponHold로 정의 (계속 붙어다님)
        equippedGun.transform.parent = weaponHold;
    }

    public void Shoot() {
        if (equippedGun != null) {
            equippedGun.Shoot();
        }
    }
}
