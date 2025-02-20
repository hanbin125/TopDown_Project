using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    private static ProjectileManager instance;
    public static ProjectileManager Instance { get { return instance; } }

    [SerializeField] private GameObject[] projectilePrefabs;

    [SerializeField] private ParticleSystem impactParticleSystem;

    private void Awake()
    {
        instance = this;
    }

    public void ShootBullet(RangeWeaponHandler rangeWeaponHandler, Vector2 startPostiion, Vector2 direction)
    {
        GameObject origin = projectilePrefabs[rangeWeaponHandler.BulletIndex];
        GameObject obj = Instantiate(origin, startPostiion, Quaternion.identity);

        ProjectileController projectileController = obj.GetComponent<ProjectileController>();
        projectileController.Init(direction, rangeWeaponHandler, this);
    }

    // 피격 파티클을 생성합니다.
    public void CreateImpactParticlesAtPostion(Vector3 position, RangeWeaponHandler weaponHandler)
    {
        // 피격 파티클을 생성합니다. impactParticleSystem에서 
        impactParticleSystem.transform.position = position;
        // 피격 파틸의 색상을 설정합니다.
        ParticleSystem.EmissionModule em = impactParticleSystem.emission;
        // 피격 파티클의 폭발량을 설정합니다.
        em.SetBurst(0, new ParticleSystem.Burst(0, Mathf.Ceil(weaponHandler.BulletSize * 5)));
        // 피격 파티클의 메인 모듈을 가져옵니다.
        ParticleSystem.MainModule mainModule = impactParticleSystem.main;
        // 피격 파티클의 속도를 설정합니다.
        mainModule.startSpeedMultiplier = weaponHandler.BulletSize * 10f;
        // 피격 파티클을 재생합니다.
        impactParticleSystem.Play();
    }
}