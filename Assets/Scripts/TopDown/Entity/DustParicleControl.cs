using UnityEngine;

// 투사체를 생성합니다. projectileManager에서
public class DustParticleControl : MonoBehaviour
{
    // 먼지 효과를 생성할지 여부를 나타냅니다.
    [SerializeField] private bool createDustOnWalk = true;
    // 먼지 효과를 생성할 파티클 시스템입니다.
    [SerializeField] private ParticleSystem dustParticleSystem;

    // 먼지 효과를 생성합니다.
    public void CreateDustParticles()
    {
        // 먼지 효과를 생성합니다.
        if (createDustOnWalk)
        {
            //먼지 효과를 정지합니다  
            dustParticleSystem.Stop();

            // 먼지 효과를 재생합니다.
            dustParticleSystem.Play();
        }
    }
}