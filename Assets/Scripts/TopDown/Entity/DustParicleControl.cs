using UnityEngine;

// ����ü�� �����մϴ�. projectileManager����
public class DustParticleControl : MonoBehaviour
{
    // ���� ȿ���� �������� ���θ� ��Ÿ���ϴ�.
    [SerializeField] private bool createDustOnWalk = true;
    // ���� ȿ���� ������ ��ƼŬ �ý����Դϴ�.
    [SerializeField] private ParticleSystem dustParticleSystem;

    // ���� ȿ���� �����մϴ�.
    public void CreateDustParticles()
    {
        // ���� ȿ���� �����մϴ�.
        if (createDustOnWalk)
        {
            //���� ȿ���� �����մϴ�  
            dustParticleSystem.Stop();

            // ���� ȿ���� ����մϴ�.
            dustParticleSystem.Play();
        }
    }
}