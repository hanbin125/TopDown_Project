using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    // Animator.StringToHash()�� ���ڿ��� ������ �ؽ� �ڵ�� ��ȯ�ϴ� �� ���˴ϴ�.
    // ���⼭�� ���ڷ� ��ȯ�� ���ڿ��� ����Ͽ� �ִϸ��̼��� �����մϴ�.
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");
    // protected�� ����� animator�� ��ӹ��� Ŭ�������� ����� �� �ֽ��ϴ�.
    protected Animator animator;
    
    protected virtual void Awake()
    {
        // GetComponentInChildren<T>()�� �ڽ� ������Ʈ���� ������Ʈ�� ã���ϴ�.
        animator = GetComponentInChildren<Animator>();  
    }

    // Move() �޼���� �̵��ϴ� ������ �޾� �ִϸ��̼��� �����մϴ�.
    public void Move(Vector2 obj)
    {
        // obj.magnitude�� obj�� ũ�⸦ ��ȯ�մϴ�.
        animator.SetBool(IsMoving, obj.magnitude > .5f);
    }

    // Damage() �޼���� �ǰ� �ִϸ��̼��� �����մϴ�.
    public void Damage()
    {
        animator.SetBool(IsDamage, true);
    }
    // InvincibilityEnd() �޼���� ���� ���°� ������ ȣ��Ǿ� �ǰ� �ִϸ��̼��� �����մϴ�.
    public void InvincibilityEnd()
    {
        animator.SetBool(IsDamage, false);
    }
}
