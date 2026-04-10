#include <vector>
#include <cstdlib>
#include <cmath>

#ifdef __cplusplus
extern "C" {
#endif


struct Particle {
    float position[3];
    float velocity[3];
    float life;
};

static std::vector<Particle> particles;
static int particleCount = 0;

// Usar atributo de GCC en lugar de declspec
void InitParticles(int count) {
    particleCount = count;
    particles.resize(count);

    for (int i = 0; i < count; i++) {
        // Posiciones iniciales aleatorias
        particles[i].position[0] = (rand() % 2000 - 1000) / 100.0f;  // -10 a 10
        particles[i].position[1] = (rand() % 2000) / 100.0f;          // 0 a 20
        particles[i].position[2] = (rand() % 2000 - 1000) / 100.0f;   // -10 a 10

        // Velocidad inicial aleatoria
        particles[i].velocity[0] = (rand() % 400 - 200) / 100.0f;     // -2 a 2
        particles[i].velocity[1] = (rand() % 300) / 100.0f;            // 0 a 3
        particles[i].velocity[2] = (rand() % 400 - 200) / 100.0f;      // -2 a 2

        particles[i].life = 1.0f;
    }
}

void UpdateParticles(float deltaTime, float speed, float gravity) {
    float dt = deltaTime * speed;

    for (int i = 0; i < particleCount; i++) {
        // Aplicar gravedad solo en el eje Y
        particles[i].velocity[1] += gravity * dt;

        // Actualizar posición
        particles[i].position[0] += particles[i].velocity[0] * dt;
        particles[i].position[1] += particles[i].velocity[1] * dt;
        particles[i].position[2] += particles[i].velocity[2] * dt;

        // Rebote en el suelo (Y = 0)
        if (particles[i].position[1] < 0) {
            particles[i].position[1] = 0;
            particles[i].velocity[1] = -particles[i].velocity[1] * 0.7f;  // Rebote con pérdida
        }

        // Reset si caen demasiado bajo
        if (particles[i].position[1] < -10) {
            particles[i].position[0] = (rand() % 2000 - 1000) / 100.0f;
            particles[i].position[1] = (rand() % 2000) / 100.0f;
            particles[i].position[2] = (rand() % 2000 - 1000) / 100.0f;
            particles[i].velocity[0] = (rand() % 400 - 200) / 100.0f;
            particles[i].velocity[1] = (rand() % 300) / 100.0f;
            particles[i].velocity[2] = (rand() % 400 - 200) / 100.0f;
        }

        // Reducir vida (opcional)
        particles[i].life -= dt * 0.5f;
        if (particles[i].life <= 0) {
            particles[i].life = 1.0f;
            particles[i].position[1] = 20.0f;  // Reiniciar arriba
        }
    }
}

Particle* GetParticles() {
    return particles.data();
}

int GetParticleCount() {
    return particleCount;
}

#ifdef __cplusplus
}
#endif