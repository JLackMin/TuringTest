using System.Diagnostics;
using UnityEngine;

namespace Midterm
{
    public class PlayerWeapon : MonoBehaviour
    {
        private IWeaponBehaviour currentWeapon;
        public GameObject shotPoint;

        public GameObject weaponReference;
        public GameObject rocketProjectile;
        public GameObject bulletProjectile;

        void Start()
        {
            SwitchWeapon(new ProjectileWeaponBehaviour(this));
        }

        void OnShoot()
        {
            currentWeapon.FireWeapon(shotPoint.transform);
        }

        void OnSwitchToProjectile()
        {
            SwitchWeapon(new ProjectileWeaponBehaviour(this));
        }
        void OnSwitchToRaycast()
        {
            SwitchWeapon(new RaycastWeaponBehaviour(this));
        }

        public void SwitchWeapon(IWeaponBehaviour newWeapon)
        {
            currentWeapon = newWeapon;
            UnityEngine.Debug.Log("Switched weapon behaviour to: " + newWeapon.ToString());
        }
    }
}
