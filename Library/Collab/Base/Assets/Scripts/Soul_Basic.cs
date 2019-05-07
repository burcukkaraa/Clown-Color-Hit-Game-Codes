using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[RequireComponent(typeof( Animator))]
[RequireComponent(typeof(Rigidbody))]
public class Soul_Basic : MonoBehaviour {
    #region Hareket Değişkenleri
    RaycastHit Groundinfo;
    Rigidbody rigidbody;
    Vector3 LocalSpeed, GlobalSpeed;
    float speed;
    bool onground;
    Animator animator;
    public float JumpPower, MaxSpeed, Accerelation;
    public float SeritSayisi, SeritGenisligi;
    #endregion


    public Vector3 MermiCalibration;
    public GameObject mermiprefab;
    public Transform Path,tabanca;
    Transform CameraTransform;

    public int balondeger;
    public Text balonscore;
    public GameObject panel_quit;


    // Use this for initialization
    void Start () {
        seritno = SeritSayisi / 2;
        Path = transform;
        rigidbody = transform.GetComponent<Rigidbody>();
        CameraTransform = Camera.main.transform;
        animator = GetComponent<Animator>();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;

        panel_quit.SetActive(false);
    }

    // Update is called once per frame
    public void Update ()
    {
        if (!panel_quit.active)
        {
            Debug.Log("panelquit aktif deği");
            LocalSpeed = LocalSpeedInput(); //input al
            GlobalSpeed = SpeedConvertToGlobal(LocalSpeed, Path, MaxSpeed, JumpPower);  //input vektörü referansa göre hareket vektörüne dönüştür
            onground = GroundCheck(0.25f); // yere basıyor muyuz kontrol et
            GrandAnimationControll(animator, MaxSpeed);  //animasyon kontrol

            balonscore.text = "" + balondeger;


            if (!cool)
            {
                cd += Time.deltaTime;
                if (cd > 6)
                {
                    cd = 0;
                    cool = true;
                    count = 0;
                }
            }
        }
       

      
    }
    public virtual void FixedUpdate()
    {
        if (!panel_quit.active)
        {
            MoveRigidbody(GlobalSpeed, rigidbody, Accerelation, onground); //hareket vektörünü rigidbody'e ver
            CharTurner(CameraTransform, onground); //karakteri harekete göre döndür
        }
      
    }

    float xpos,seritno;
    public virtual Vector3 LocalSpeedInput()
    {
        Vector3 loclsped = Vector3.zero;
        loclsped.z = 1;
        //  loclsped.x = UnityEngine.Input.GetAxis("Horizontal");
        if (Input.touchCount>0)
        {
            if (Input.GetTouch(0).deltaPosition.x > 0) { seritno++; }
            if (Input.GetTouch(0).deltaPosition.x < 0) { seritno--; }
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.D)) { seritno++; }
        if (UnityEngine.Input.GetKeyDown(KeyCode.A)) { seritno--; }
        
        seritno= Mathf.Clamp(seritno,0,SeritSayisi-1);
        xpos = Path.position.x - (SeritSayisi / 2) * SeritGenisligi+SeritGenisligi/2+seritno*SeritGenisligi;

        if (UnityEngine.Input.GetKey(KeyCode.Space)) { loclsped.y = 1; }
        return loclsped;
    }  //inputa göre yerel hareket vektörü oluşturur

    public virtual Vector3 SpeedConvertToGlobal(Vector3 local, Transform Ground, float speed, float JumpPower)
    {
        Vector3 GlobalVector;
        float Y = local.y;
        local.y = 0;
        local.x = xpos - transform.position.x;
        GlobalVector = Ground.TransformDirection(local.normalized);
        GlobalVector *= speed;
        GlobalVector.y = Y * JumpPower;

        return GlobalVector;
    } //yerel hareket vektörünü bir referansa göre global vektöre dönüştürür

    protected bool GroundCheck(float groundcheckdistance)
    {

        if (Physics.Raycast(transform.position + (Vector3.up * .1f), Vector3.down, out Groundinfo, groundcheckdistance))
        {
            Path = Groundinfo.transform.root;
            return true;
        }
        else { Path = this.transform; return false; }
    }  //aşağı doğru groundchecdistance mesafesinde zemin olup olmadığını kontrol eder.

    public virtual void CharTurner(Transform Cam, bool onground, bool incombat = false)
    {
        Quaternion direction;
        
            direction = Quaternion.FromToRotation(Vector3.forward, transform.forward.normalized);
            direction.z = 0;
            direction.x = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, direction, 5 * Time.deltaTime);

    }  //karakteri kameraya göre döndürür

    protected void MoveRigidbody(Vector3 Globalspeed, Rigidbody rigidboby, float Accerelation, bool onground)
    {
        if (onground)
        {
            Vector3 v;
            v = Vector3.Lerp(rigidboby.velocity, Globalspeed, Accerelation * Time.deltaTime);
            v.y = GlobalSpeed.y;
            rigidboby.velocity = v;
        }
    }  //global hareket vektörünü rigidbody' ile hıza dönüştürür

    protected virtual void GrandAnimationControll(Animator Any, float speedlimit, bool isincombat=false, bool shielding=false)
    {
        Vector3 LocalSpeed = transform.InverseTransformDirection(rigidbody.velocity);
        if (isincombat)
        {
            Any.SetFloat("Zpercent", LocalSpeed.z);
            Any.SetFloat("Xpercent", LocalSpeed.x);
        }
        else
        {
            Any.SetFloat("Zpercent", rigidbody.velocity.magnitude / speedlimit);
        }
        Any.SetBool("Incombat", isincombat);
        Any.SetBool("Shielding", shielding);
    }  //girdilere göre animasyonları yönetir

    int count;bool cool;float cd;

   public void ateset(  Color color)
    {
        if (count++ < 4 && balondeger>0 )
        {
            balondeger--;
            GameObject a = Instantiate(mermiprefab);
            a.transform.SetParent(tabanca);
            a.transform.localPosition = MermiCalibration;
            a.GetComponent<Bullet>().BulletColor = color;
            cool = false;
        }
    }  // input olduğunda ateş eder

    private void OnCollisionEnter(Collision collision)
    {
        ColorLock CL = collision.collider.GetComponent<ColorLock>();
        Debug.Log("Çarpışma algılandı");
        if (CL != null)
        {
            // SceneManager.LoadScene("gameovermenu");
            panel_quit.SetActive(true);
            balondeger = 0;
            balonscore.text = ""+balondeger;
        }

        if (collision.gameObject.name=="Cannon")
        {
            Debug.Log("Cannon ile tamas algılandı");
            CameraTransform.GetComponent<YolScript>().AddScore(100);
        }
    }
 
    public void touchcontrollerleft()
    {
        seritno--;
    }
    public void touchcontrollerright()
    {
     
        seritno++;
    }
    
   Vector3 vec = new Vector3(0, 7, 0);
    public void touchcontrollerjump() // üzerinde çalışılıyor.
    {
        LocalSpeed = LocalSpeedInput();
        GlobalSpeed = SpeedConvertToGlobal(LocalSpeed, Path, MaxSpeed, JumpPower);

       
        rigidbody.AddForce(vec * JumpPower);
        Debug.Log("Jump ");
       
       
    }

    /*
     public void touchmove()      
     {
            Vector3 loclsped = Vector3.zero;
            loclsped.z = 1;

            LocalSpeed = LocalSpeedInput();
            GlobalSpeed = SpeedConvertToGlobal(LocalSpeed, Path, MaxSpeed, JumpPower);

            if (Input.touchCount > 0 && !(EventSystem.current.IsPointerOverGameObject()))
            {


                onground = GroundCheck(0.25f);
                GrandAnimationControll(animator, MaxSpeed);

                Touch touch = Input.GetTouch(0);
                float  width = (float)Screen.width / 2.0f;




                 if (touch.position.x < width && touch.phase == TouchPhase.Began)
                 {
                     seritno--;
                 }

                 else if (touch.position.x > width && touch.phase == TouchPhase.Began)
                 {
                     seritno++;
                 }

             else
             {
                 LocalSpeed = LocalSpeedInput();
                 GlobalSpeed = SpeedConvertToGlobal(LocalSpeed, Path, MaxSpeed, JumpPower);
                 onground = GroundCheck(0.25f);
                 GrandAnimationControll(animator, MaxSpeed);
             }
            }
     }
     */

}
