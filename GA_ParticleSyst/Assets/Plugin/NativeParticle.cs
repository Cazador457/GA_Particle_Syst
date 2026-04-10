using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class NativeParticle : MonoBehaviour
{
    // Estructura que debe coincidir con la de C++
    [StructLayout(LayoutKind.Sequential)]
    public struct Particle
    {
        public Vector3 position;
        public Vector3 velocity;
        public float life;
    }

    // Importar funciones de C++
    [DllImport("NativeParticle")]
    private static extern void InitParticles(int count);

    [DllImport("NativeParticle")]
    private static extern void UpdateParticles(float deltaTime, float speed, float gravity);

    [DllImport("NativeParticle")]
    private static extern IntPtr GetParticles();

    [DllImport("NativeParticle")]
    private static extern int GetParticleCount();

    public int particleCount = 1000;
    public float simulationSpeed = 1.0f;
    public float gravity = -9.81f;  // Gravedad añadida
    public GameObject particlePrefab;

    private Transform[] particleTransforms;

    void Start()
    {
        InitParticles(particleCount);

        particleTransforms = new Transform[particleCount];
        for (int i = 0; i < particleCount; i++)
        {
            particleTransforms[i] = Instantiate(particlePrefab).transform;

            // Opcional: Posiciones iniciales aleatorias
            float x = UnityEngine.Random.Range(-10f, 10f);
            float y = UnityEngine.Random.Range(0f, 20f);
            float z = UnityEngine.Random.Range(-10f, 10f);
            particleTransforms[i].position = new Vector3(x, y, z);
        }
    }

    void Update()
    {
        // Actualizar lógica en C++ con gravedad
        UpdateParticles(Time.deltaTime, simulationSpeed, gravity);

        // Obtener y aplicar posiciones
        IntPtr particlePtr = GetParticles();
        int size = Marshal.SizeOf(typeof(Particle));

        for (int i = 0; i < particleCount; i++)
        {
            IntPtr currentParticlePtr = new IntPtr(particlePtr.ToInt64() + i * size);
            Particle p = Marshal.PtrToStructure<Particle>(currentParticlePtr);
            particleTransforms[i].position = p.position;
        }
    }
}