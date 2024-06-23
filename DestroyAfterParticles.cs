using UnityEngine;

public class DestroyAfterParticles : MonoBehaviour
{
    private ParticleSystem particles;

    void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (particles && !particles.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
