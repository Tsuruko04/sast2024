using UnityEngine;

public class GeneralController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Vector3 target;
    public bool captureHim = false;
    Animator animator;
    void Start()
    {
        target = transform.position + Vector3.forward * 100;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (transform.position != target)
        {
            transform.LookAt(target);
            animator.SetBool("isMoving", true);
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
        else {
            animator.SetBool("isMoving", false);
        }

        if (captureHim)
        {
            captureHim = false;
            animator.SetTrigger("isCaptured");
            target = transform.position;
        }
    }


    // void Update()
    // {
    //     if (transform.position != target)
    //     {
    //         isMoving = true;
    //         animator.SetBool("isMoving", true);
    //         transform.rotation = Quaternion.LookRotation(target - transform.position);
    //         float step = moveSpeed * Time.deltaTime;
    //         transform.position = Vector3.MoveTowards(transform.position, target, step);
    //     }
    //     else if (transform.position == target && isMoving)
    //     {
    //         isMoving = false;
    //         animator.SetBool("isMoving", false);
    //     }
    // }

    public GameObject commandAnim;
    private GameObject nowCommand;

    public GameObject deffendAnim;
    private GameObject nowDefend;

    public GameObject immuneAnim;
    private GameObject nowImmune;

    void EffectsMove(Vector3 pos)
    {
        if (nowCommand != null)
        {
            nowCommand.transform.position = pos;
        }
        if (nowDefend != null)
        {
            nowDefend.transform.position = pos;
        }
        if (nowImmune != null)
        {
            nowImmune.transform.position = pos;
        }
    }

    // 播放动画
    bool isMoving = false;

    

    

    public void SetAcPos(Vector3 pos)
    {
        transform.position = pos;
        target = transform.position;
        if (nowCommand != null)
            nowCommand.transform.position = transform.position;
        if (nowDefend != null)
            nowDefend.transform.position = transform.position;
        if (nowImmune != null)
            nowImmune.transform.position = transform.position;
    }

    public void Move(Vector3 _target)
    {
        target = _target;
    }

    
    public void SetCmdAnimOn()
    {
        if (nowCommand == null)
        {
            nowCommand = Instantiate(commandAnim);
            nowCommand.transform.position = transform.position;
        }
    }

    public void SetCmdAnimOff()
    {
        if (nowCommand != null)
        {
            Destroy(nowCommand);
        }
    }

    public void SetDfdAnimOn()
    {
        if (nowDefend == null)
        {
            nowDefend = Instantiate(deffendAnim);
            nowDefend.transform.position = transform.position;
        }
    }

    public void SetDfdAnimOff()
    {
        if (nowDefend != null)
        {
            Destroy(nowDefend);
        }
    }

    public void SetImnAnimOn()
    {
        if (nowImmune == null)
        {
            nowImmune = Instantiate(immuneAnim);
            nowImmune.transform.position = transform.position;
        }
    }

    public void SetImnAnimOff()
    {
        if (nowImmune != null)
        {
            Destroy(nowImmune);
        }
    }

    private void OnDestroy()
    {
        SetCmdAnimOff();
        SetDfdAnimOff();
        SetImnAnimOff();
    }
}
