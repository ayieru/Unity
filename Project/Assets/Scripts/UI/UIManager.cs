using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    //現在のUIの状態保存
    public enum UI_State{
        Player,
        ShopChoice,
        WeaponMenu,
        ObjectShop,
        WeaponPurchase,
        WeaponUpdate,
        Max
    }
    public UI_State state;

    //Panelオブジェクトをセットする
    [SerializeField] GameObject[] GOState = new GameObject[(int)UI_State.Max];

    bool cursorLock = true;

    // Start is called before the first frame update
    void Start()
    {
        state = UI_State.Player;
        GOState[(int)state].SetActive(true);
        for(int i = 1; i < (int)UI_State.Max; i++)
        {
            GOState[i].SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SetUIState(UI_State.ShopChoice);
            cursorLock = false;
            UpdareCursorLock();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnUI();
        }
        UpdareCursorLock();
    }

    // UI画面変更
    void SetUIState(UI_State state)
    {
        GOState[(int)this.state].SetActive(false);
        this.state = state;
        GOState[(int)this.state].SetActive(true);
    }

    //UI戻るときの関数
    void ReturnUI()
    {
        if(state != UI_State.Player){
            if(state == UI_State.WeaponMenu || state == UI_State.ObjectShop)
            {
                SetUIState(UI_State.ShopChoice);
            }
            else if(state == UI_State.WeaponPurchase || 
                state == UI_State.WeaponUpdate)
            {
                SetUIState(UI_State.WeaponMenu);
            }
            else
            {
                UI_State tmpState = this.state - 1;
                SetUIState(tmpState);
            }
        }
        else 
        {
            cursorLock = false;
        }        
    }

    //プレイヤー画面
    public void SetPlayerUI()
    {
        cursorLock = true;
        SetUIState(UI_State.Player);
    }

    //武器or配置物選択画面
    public void SetWeapon_or_Object()
    {
        SetUIState(UI_State.ShopChoice);
    }

    public void SetWeaponPurchase()
    {
        SetUIState(UI_State.WeaponPurchase);
    }
    public void SetWeaponUpdate()
    {
        SetUIState(UI_State.WeaponUpdate);
    }

    //武器の強化or購入画面
    public void SetWeaponMenu()
    {
        SetUIState(UI_State.WeaponMenu);
    }
    //武器選択画面
    public void SelectWeapon()
    {
        SetUIState(UI_State.WeaponMenu);
    }

    //配置物選択画面
    public void SelectObject()
    {
        SetUIState(UI_State.ObjectShop);
    }

    public void GameOver()
    {
        cursorLock = false;
    }

    public void GameClear()
    {
        cursorLock = false;
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
