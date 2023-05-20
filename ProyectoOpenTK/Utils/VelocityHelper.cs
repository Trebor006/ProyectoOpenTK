using System;
using OpenTK;

namespace ProyectoOpenTK.Utils
{
    public class VelocityHelper
    {
        public static double CalculateVelocity(Vector3 posA, Vector3 posB, long time)
        {
            // Calculate the difference in position between the two points.
            Vector3 deltaPosition = posB - posA;

            // Calculate the velocity by dividing the difference in position by the time.
            double velocity = deltaPosition.Length / time;

            // Return the velocity.
            return velocity;
        }

        public float CalculateRotation(float currentRotation, float targetRotation, float time)
        {
            float degreesPerSecond = (targetRotation - currentRotation) / time;
            float degreesToRotate = degreesPerSecond * time;

            return degreesToRotate;
        }
    }
}