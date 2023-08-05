using Fusion;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField] private NetworkCharacterControllerPrototype MainCharacter;

    [SerializeField] private Animator animator;
    private int Anim_Jump;
    private int Anim_Punch;
    private int Anim_Speed;
    public bool IsEnableJoyStick;
    public Vector2 joyStickVal;
    void Start()
    {
        Anim_Jump = Animator.StringToHash("jump");
        Anim_Punch = Animator.StringToHash("punch");
        Anim_Speed = Animator.StringToHash("speed");
    }
    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            data.direction.Normalize();
            MainCharacter.Move(data.direction);
        }
        if (IsEnableJoyStick)
        {
            //MeshAgent.destination = transform.position + new Vector3(joyStickVal.x, 0, joyStickVal.y);
            MainCharacter.Move(new Vector3(joyStickVal.x, 0, joyStickVal.y));
        }
        PlayerAnimation();
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
        animator.SetFloat(Anim_Speed, MainCharacter.Velocity.magnitude);
    }
}
