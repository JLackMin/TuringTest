using UnityEngine;

namespace Midterm
{
    public class ProjectileWeaponBehaviour : IWeaponBehaviour
    {
        PlayerWeapon weaponScript;
        public ProjectileWeaponBehaviour(PlayerWeapon _weaponScript)
        {
            weaponScript = _weaponScript;
            weaponScript.weaponReference.GetComponent<MeshRenderer>().material.color = Color.purple;
        }
        public void FireWeapon(Transform _inTransform)
        {
            Debug.Log("Firing projectile weapon...");

            
        }
    }
}
