using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected WeaponData weaponData;
    public int level { get; protected set; }
    public void SetLevel(int level)
    {
        this.level = level;
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

    protected float power = 50;

    protected bool shootFlag = true;
    protected float shootElapsedTime = 0;
    protected float shootRate = 1f;

    public AudioClip S_shot;
    public AudioClip S_reload;
    private AudioSource audioSource;

    void Awake()
    {
        magazine.level = level;
        audioSource = GetComponent<AudioSource>();
    }
    public void Reload()
    {
        audioSource.PlayOneShot(S_reload);
        magazine.LoadMagazine();
    }

    public abstract void Shoot();

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
