using TMPro;
using UnityEngine;

public class UI_PrintAmmunition : MonoBehaviour
{

    // SET PLAYER STATS AS NEW SCRIPT PLS
    [Header("------AMMO------")]
    public PlayerShootController _playerShoot; // REPLACE WITH PLAYER STATS LATER

    public TextMeshProUGUI UI_AmmoText;

    private void Update()
    {

        string  printCurrentAmmo = _playerShoot.Ammo.ToString();
        UI_AmmoText.text = printCurrentAmmo;


    }

}
