using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    // Animator.StringToHash()는 문자열을 고유한 해시 코드로 변환하는 데 사용됩니다.
    // 여기서는 숫자로 변환된 문자열을 사용하여 애니메이션을 제어합니다.
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");
    // protected로 선언된 animator는 상속받은 클래스에서 사용할 수 있습니다.
    protected Animator animator;
    
    protected virtual void Awake()
    {
        // GetComponentInChildren<T>()는 자식 오브젝트에서 컴포넌트를 찾습니다.
        animator = GetComponentInChildren<Animator>();  
    }

    // Move() 메서드는 이동하는 방향을 받아 애니메이션을 제어합니다.
    public void Move(Vector2 obj)
    {
        // obj.magnitude는 obj의 크기를 반환합니다.
        animator.SetBool(IsMoving, obj.magnitude > .5f);
    }

    // Damage() 메서드는 피격 애니메이션을 제어합니다.
    public void Damage()
    {
        animator.SetBool(IsDamage, true);
    }
    // InvincibilityEnd() 메서드는 무적 상태가 끝나면 호출되어 피격 애니메이션을 종료합니다.
    public void InvincibilityEnd()
    {
        animator.SetBool(IsDamage, false);
    }
}
