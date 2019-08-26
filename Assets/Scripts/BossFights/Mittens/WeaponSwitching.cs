using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitching : MonoBehaviour, InputActions.IMittensBossFightActions
{
    private InputActions Controls;

    public int selectedWeapon = 0;

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    void Switch()
    {
        if (selectedWeapon >= transform.childCount -1)
        {
            selectedWeapon = 0;
        }else
            selectedWeapon++;

        SelectWeapon();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnSwitchWeapons(InputAction.CallbackContext context)
    {
        Switch();
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
