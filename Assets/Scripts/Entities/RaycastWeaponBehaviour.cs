using UnityEngine;

namespace Midterm
{
    public class RaycastWeaponBehaviour : IWeaponBehaviour
    {
        PlayerWeapon weaponScript;
        public RaycastWeaponBehaviour(PlayerWeapon _weaponScript)
        {
            weaponScript = _weaponScript;
            weaponScript.weaponReference.GetComponent<MeshRenderer>().material.color = Color.green;
        }

        public void FireWeapon(Transform _inTransform)
        {
            Debug.Log("Firing raycast weapon...");
        }
    }
}
