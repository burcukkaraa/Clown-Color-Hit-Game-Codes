using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyinghatScript : MonoBehaviour {

    public Button ucansapkabuton;
    public GameObject ucansapkaobject;
    public OzelGuc ucansapka;

    public void butonvisible()
    {
        ucansapkabuton.GetComponent<Button>().image.color = new Color(255, 255, 255, 255);
        ucansapkabuton.enabled = true;
 
    }
    public void ucansapkaaktiet()
    {
        ucansapkaobject.SetActive(true);
    }
    //
    void Start ()
    {

        //ucansapkabuton = GameObject.Find("Button_ucansapka").GetComponent<Button>();
        //ucansapkabuton.enabled = false;
        ucansapkaobject = GameObject.Find("/Palyaçoviç/Armature/Bone/Bone.001/Bone.002/Bone.003/Bone.004/Bone.004_end/ucan sapka");
     ucansapkaobject.SetActive(false);

    }

    // Update is called once per frame
    void Update ()
    {
      
	}

    private void OnTriggerEnter(Collider other)
    {
        Soul_Basic SB = other.GetComponent<Soul_Basic>();
        if (other.gameObject.name== "Palyaçoviç")
        {
            Debug.Log("flying hat ile tamas algılandı");
            Destroy(gameObject);
            // butonvisible();




        }

    }
}
