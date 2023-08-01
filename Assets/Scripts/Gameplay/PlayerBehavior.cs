using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using static UIAction;
using Lean.Gui;
//using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject Random_Pref;
    [SerializeField] private NavMeshAgent MeshAgent;
    [SerializeField] private Animator animator;
    private int Anim_Jump;
    private int Anim_Punch;
    private int Anim_Speed;
    private bool IsEnableJoyStick;
    private Vector2 joyStickVal;
    // Start is called before the first frame update
    void Start()
    {
        //PositionChange = 1;
        //controller = GameObject.Find("GameplayController").GetComponent<GameplayController>();
        //agent = gameObject.GetComponent<NavMeshAgent>();
        Anim_Jump = Animator.StringToHash("jump");
        Anim_Punch = Animator.StringToHash("punch");
        Anim_Speed = Animator.StringToHash("speed");
    }
    // Update is called once per frame
    void Update()
    {        
        PlayerControll();
        PlayerAnimation();
    }
    private void PlayerControll()
    {
        if (IsEnableJoyStick)
        {            
            MeshAgent.destination = transform.position + new Vector3(joyStickVal.x, 0, joyStickVal.y);
        }
        Vector3 movement = new(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(movement != Vector3.zero)
        {
            MeshAgent.destination = transform.position + movement;
        }       
        /*
        Vector3 NewPos = transform.position;
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
            {
                MeshAgent.destination = hit.point;
            }
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            //pos.z += speed * Time.deltaTime;
            NewPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + PositionChange);
            //MeshAgent.destination = NewPos;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //pos.x -= speed * Time.deltaTime;
            NewPos = new Vector3(transform.position.x - PositionChange, transform.position.y, transform.position.z);
            //MeshAgent.destination = NewPos;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //pos.z -= speed * Time.deltaTime;
            NewPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - PositionChange);
            //MeshAgent.destination = NewPos;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //pos.x += speed * Time.deltaTime;
            NewPos = new Vector3(transform.position.x + PositionChange, transform.position.y, transform.position.z);
            //MeshAgent.destination = NewPos;
        }
        MeshAgent.destination = NewPos;
        */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //pos.y += speed * 10 * Time.deltaTime;
            //gameObject.transform.position += new Vector3(0, speed * 10 * Time.deltaTime, 0);
            animator.SetTrigger(Anim_Jump);
        }
        //@object.transform.position = pos;
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 1000))
            {
                PrefSpawn(hit);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger(Anim_Punch);
        }
    }
    public void OnDown()
    {
        IsEnableJoyStick = true;
    }
    public void OnUp()
    {
        IsEnableJoyStick = false;
        joyStickVal = Vector2.zero;
    }
    public void OnSet(Vector2 val)
    {
        if (IsEnableJoyStick)
        {
            joyStickVal = val;
        }
    }
    private void PlayerAnimation()
    {
        animator.SetFloat(Anim_Speed, MeshAgent.velocity.magnitude);
    }
    private void PrefSpawn(RaycastHit hit)
    {
        //GameObject Barrel = Instantiate(Random_Pref, new Vector3(Random.Range(10, 20), 0, Random.Range(10, 20)), Quaternion.identity);
        GameObject Barrel = Instantiate(Random_Pref, transform.position, Quaternion.identity);
        Rigidbody rb = Barrel.GetComponent<Rigidbody>();
        rb.AddForce((hit.point - transform.position) * 50);
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == GameConstant.TAG_CROP)
        {
            crop = other.gameObject.GetComponent<CropPlan>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        crop = null;
    }
    

    public void Carrot()
    {
        crop?.Crop(1);
    }
    public void Corn()
    {
        crop?.Crop(2);
    }
    public void Eggplant()
    {
        crop?.Crop(3);
    }
    public void Pumpkin()
    {
        crop?.Crop(4);
    }
    public void Tomato()
    {
        crop?.Crop(5);
    }
    public void Turnip()
    {
        crop?.Crop(6);
    }
    */
}
