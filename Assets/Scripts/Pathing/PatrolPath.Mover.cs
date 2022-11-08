using System.Collections;
using UnityEngine;

namespace Pathing
{
    public partial class PatrolPath
    {
        /// <summary>
        /// The Mover class oscillates between start and end points of a path at a defined speed.
        /// </summary>
        public class Mover
        {
            PatrolPath path;
            float p = 0;
            float duration;
            float startTime;

            public Mover(PatrolPath path, float time)
            {
                this.path = path;
                this.duration = time;
                this.startTime = Time.time;
                Position = path.transform.TransformPoint(path.startPosition);
                LerpToEndPos();
            }

            private void LerpToEndPos()
            {
                LeanTween.value(path.gameObject, f => Position = path.transform.TransformPoint(Vector2.Lerp(path.startPosition, path.endPosition, f)), 0f, 1f,
                    duration).setDelay(path.startPosPause).setOnComplete(LerpToStartPos);
            }

            private void LerpToStartPos()
            {
                LeanTween.value(path.gameObject, f => Position = path.transform.TransformPoint(Vector2.Lerp(path.startPosition, path.endPosition, f)), 1f, 0f,
                    duration).setDelay(path.endPosPause).setOnComplete(LerpToEndPos);
            }

            public Vector2 Position { get; private set; }

            /// <summary>
            /// Get the position of the mover for the current frame.
            /// </summary>
            /// <value></value>
            // public Vector2 Position
            // {
            //     get
            //     {
            //         p = Mathf.InverseLerp(0, duration, Mathf.PingPong(Time.time - startTime, duration));
            //         return path.transform.TransformPoint(Vector2.Lerp(path.startPosition, path.endPosition, p));
            //     }
            // }
        }
    }
}