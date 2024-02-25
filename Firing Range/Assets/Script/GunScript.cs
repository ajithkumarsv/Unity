using System.Collections;
using UnityEngine;
using DG.Tweening;
public class GunScript : MonoBehaviour
{
    public float fireRate = 0.5f;       // Rate of fire in bullets per second
    public float reloadTime = 1f;       // Time it takes to reload in seconds
    public int magazineSize = 10;        // Maximum bullets in a magazine
    public Transform muzzle;            // Point where bullets are spawned
    public GameObject bulletPrefab;     // Prefab of the bullet object
    public Animator animator;           // Animator component for animations
    public Transform aimTransform;      // Transform for aiming position
    [SerializeField]
    private int currentAmmo;            // Current bullets in the magazine
    private bool isReloading;           // Flag for reloading
    private bool isAiming;              // Flag for aiming
    private float nextFireTime;         // Time of the next allowed shot



    [SerializeField]
    Camera cam;
    [SerializeField]
    Camera ScopeCam;
    [SerializeField]
    LayerMask hitlayer;
    [SerializeField]
    LayerMask aimLayer;
    [SerializeField]
    LayerMask defLayer;
    [SerializeField]
    GameObject decal;
    [SerializeField] float mousespeed;
    PlayerInput input;


    public float maxSwayAmount = 2f;
    public float smoothAmount = 6f;

    private Quaternion initialRotation;

    [SerializeField] float min_zoom, max_zoom;
    [SerializeField] float cur_zoom;
    [SerializeField] float def_zoom;
    [SerializeField] float aim_fov=10;

    [SerializeField] Vector3 aimpPosition;
    [SerializeField] Vector3 aimRotation;
    [SerializeField] Ease aimEase;
    Vector3 normalPosition;

    private void Awake()
    {
        input = new PlayerInput();
       
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    private void Start()
    {
        initialRotation = transform.localRotation;
        cam = GetComponent<Camera>();
        currentAmmo = magazineSize;
        isReloading = false;
        isAiming = false;
    }

    private void Update()
    {
        //if (!InputManager.IsInputEnabled) return;
        MoveGun();
        if (isReloading)
            return;

        
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime && currentAmmo>0)
        {
            nextFireTime = Time.time + 1f / fireRate;
            
            Shoot();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Aiming();
        }


        else if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("MOouseUP");
            StopAim();
            //cam.DOFieldOfView(def_zoom, 0.5f);

        }

    }

    private void Aiming()
    {
        isAiming = true;
        //transform.GetChild(0).localPosition = aimpPosition;
        transform.GetChild(0).DOLocalMove(aimpPosition, 0.5f).SetEase(aimEase);
        //cam.cullingMask = aimLayer;
        //GameUIController.Instance?.CrossHair(true);
        cam.DOFieldOfView(aim_fov, 0.5f).SetEase(aimEase);
        //cam.fieldOfView =  aim_fov;
    }

    public void MoveGun()
    {
        Vector3 angles= initialRotation.eulerAngles;
        Vector2 v = input.Movement.Move.ReadValue<Vector2>();
        angles.x += -1*v.y * mousespeed *Time.deltaTime;
        angles.y += v.x * mousespeed * Time.deltaTime;
        initialRotation.eulerAngles = angles;
        float swayX = Mathf.PerlinNoise(Time.time * smoothAmount, 0) * 2 - 1;
        float swayY = Mathf.PerlinNoise(0, Time.time * smoothAmount) * 2 - 1;
        swayX *= maxSwayAmount;
        swayY *= maxSwayAmount;


        Quaternion finalRotation = Quaternion.Euler(0, swayX, swayY);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, finalRotation * initialRotation, Time.deltaTime * smoothAmount);
        Vector2 scroll = input.Movement.zoom.ReadValue<Vector2>().normalized;
        if (isAiming)
        {
            //cam.fieldOfView += scroll.y;
            //cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, min_zoom, max_zoom);
        }
    }

    private void Shoot()
    {
        animator.SetTrigger("Fire"); // Trigger fire animation

        // Spawn a bullet at the muzzle position and rotation
        //Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
    }

    //Animator trigger
    public void fireTrigger()
    {
        
        Ray ray = ScopeCam.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ScopeCam.transform.position,ScopeCam.transform.forward, out RaycastHit hit, 1000, hitlayer))
        {
            Debug.Log("Hit ");
            if (hit.collider.tag == "target")
            {
                hit.collider.GetComponent<Target>().OnHit(hit.point);
                Instantiate(decal,hit.point,Quaternion.identity);

            }
        }
        currentAmmo--;
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        GetComponent<CameraShake>().Recoil();
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        animator.SetTrigger("Reload"); // Trigger reload animation

        yield return new WaitForSeconds(reloadTime);

        animator.ResetTrigger("Reload");
        currentAmmo = magazineSize;
        isReloading = false;
    }

    //private IEnumerator SniperAim()
    //{

    //}
    //private IEnumerator SniperStopAim()
    //{

    //}
    public void StopAim()
    {
        isAiming = false;
        cam.DOFieldOfView(def_zoom, 0.5f).SetEase(aimEase);
        transform.GetChild(0).DOLocalMove(Vector3.zero, 0.5f).SetEase(aimEase);
    }
}
