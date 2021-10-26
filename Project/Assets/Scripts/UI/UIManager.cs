using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Panelオブジェクトをセットする
    [SerializeField] GameObject P_Player;
    [SerializeField] GameObject P_ShopChoice;
    [SerializeField] GameObject P_WeaponShop;
    [SerializeField] GameObject P_ObjectShop;
    [SerializeField] GameObject P_Update;
    [SerializeField] GameObject P_GameClear;
    [SerializeField] GameObject P_GameOver;

    //現在のUIの状態保存
    enum UI_State{
        Player,
        ShopChoice,
        WeaponShop,
        ObjectShop,
    }
    UI_State state;

    bool cursorLock = true;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerUI();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SetWeapon_or_Object();
            UpdareCursorLock();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (state)
            {
                case UI_State.ShopChoice:
                    SetPlayerUI();
                    break;

                case UI_State.WeaponShop:
                    SetWeapon_or_Object();
                    break;

                case UI_State.ObjectShop:
                    SetWeapon_or_Object();
                    break;

                default:
                    break;
            }
        }
        UpdareCursorLock();
    }

    //プレイヤー画面
    public void SetPlayerUI()
    {
        state = UI_State.Player;
        cursorLock = true;

        P_Player.SetActive(true);
        P_ShopChoice.SetActive(false);
        P_WeaponShop.SetActive(false);
        P_ObjectShop.SetActive(false);
        P_Update.SetActive(false);
        P_GameClear.SetActive(true);
        P_GameOver.SetActive(false);
    }

    //武器or配置物選択画面
    public void SetWeapon_or_Object()
    {
        state = UI_State.ShopChoice;
        cursorLock = false;

        P_Player.SetActive(false);
        P_ShopChoice.SetActive(true);
        P_WeaponShop.SetActive(false);
        P_ObjectShop.SetActive(false);
        P_Update.SetActive(false);
    }

    //武器選択画面
    public void SelectWeapon()
    {
        state = UI_State.WeaponShop;

        P_ShopChoice.SetActive(false);
        P_WeaponShop.SetActive(true);
    }

    //配置物選択画面
    public void SelectObject()
    {
        state = UI_State.ObjectShop;

        P_ShopChoice.SetActive(false);
        P_ObjectShop.SetActive(true);
    }

    public void GameOver()
    {
        cursorLock = false;

        P_Player.SetActive(false);
        P_ShopChoice.SetActive(false);
        P_WeaponShop.SetActive(false);
        P_ObjectShop.SetActive(false);
        P_Update.SetActive(false);
        P_GameClear.SetActive(false);
        P_GameOver.SetActive(true);
    }

    public void GameClear()
    {
        cursorLock = false;

        P_Player.SetActive(false);
        P_ShopChoice.SetActive(false);
        P_WeaponShop.SetActive(false);
        P_ObjectShop.SetActive(false);
        P_Update.SetActive(false);
        P_GameClear.SetActive(true);
        P_GameOver.SetActive(false);
    }

    private void UpdareCursorLock()
    {
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }


}
