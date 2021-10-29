using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected WeaponData weaponData;
    public int level { get; protected set; } = 0;
    public void SetLevel(int level)
    {
        //this.level = level;
    }
    public void UPLevel()
    {
        this.level++;
        Debug.Log(level);
    }

    protected float damage;

    [SerializeField]
    protected GameObject GO_firingPoint;

    [SerializeField]
    public Magazine magazine; //{ get; protected set; }

    protected float power;
    protected bool shootingFrag = false;
    protected bool shootFlag = true;
    protected float shootElapsedTime = 0;
    [SerializeField]
    protected float shootRate = 1f;

    //Bulletに情報を渡す用
    protected Player playerScript;

    //リロード
    protected bool reloadFrag = false;
    protected float reloadElapsedTime = 0;
    protected float reloadTime;

    //マズルフラッシュ
    [SerializeField] protected ParticleSystem MazzuleFlash;

    //サウンド
    public AudioClip shot;
    public AudioClip reload;
    protected AudioSource audioSource;

    protected void Awake()
    {
        level = 0;
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        magazine.level = level;
        power = weaponData.damage[level];
        reloadTime = weaponData.reload[level];
        shootRate = weaponData.rate[level];
        audioSource = GetComponent<AudioSource>();
    }

    public void Reload()
    {

        if (!reloadFrag)
        {
            audioSource.PlayOneShot(reload);
            reloadFrag = true;
        }
    }

    public abstract void ReloadUpdate();

    public abstract void Shoot();

    public void ShootEnd()
    {
        shootingFrag = false;
    }

    protected Vector3 GetFPPosition()
    {
        Vector3 position;

        if (GO_firingPoint == null)
        {
            position = transform.position;
        }
        else
        {
            position = GO_firingPoint.transform.position;
        }

        return position;
    }

    protected Vector3 GetFPForward()
    {
        Vector3 forward;

        if (GO_firingPoint == null)
        {
            forward = transform.forward;
        }
        else
        {
            forward = GO_firingPoint.transform.forward;
        }

        return forward.normalized;
    }
}
