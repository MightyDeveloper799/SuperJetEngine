using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace SuperJet
{
    public class ParticleSystem
    {
        private List<Particle> particles;
        private Random random;

        public ParticleSystem()
        {
            particles = new List<Particle>();
            random = new Random();
        }

        public void Emit(int count)
        {
            for(int i = 0; i < count; i++)
            {
                var position = new Vector3((float)(random.NextDouble() * 2 - 1), (float)(random.NextDouble() * 2 - 1), 0);
                var velocity = new Vector3((float)(random.NextDouble() * 2 - 1), (float)(random.NextDouble() * 2 - 1), 0);
                var color = new Vector3(1.0f, (float)random.NextDouble(), (float)random.NextDouble()); 
                var life = 1.0f; 
                particles.Add(new Particle(position, velocity, color, life));
            }
        }

        public void Update(float deltaTime)
        {
            particles.RemoveAll(p => p.Life <= 0);

            foreach(var particle in particles)
            {
                particle.Update(deltaTime);
            }
        }

        public void Render()
        {
            foreach(var particle in particles)
            {
                GL.Color3(particle.Color.X, particle.Color.Y, particle.Color.Z);
                GL.Begin(PrimitiveType.Quads);
                GL.Vertex3(particle.Position.X - 0.01f, particle.Position.Y - 0.01f, 0);
                GL.Vertex3(particle.Position.X + 0.01f, particle.Position.Y - 0.01f, 0);
                GL.Vertex3(particle.Position.X + 0.01f, particle.Position.Y + 0.01f, 0);
                GL.Vertex3(particle.Position.X - 0.01f, particle.Position.Y + 0.01f, 0);
                GL.End();
            }
        }
    }
}
