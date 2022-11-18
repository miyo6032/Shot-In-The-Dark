using System.Linq;
using Pathing;
using UnityEditor;
using UnityEngine;

namespace Custom_Editors
{
    [CustomEditor(typeof(NPatrolPath))]
    public class NPatrolPathEditor : Editor
    {
        private void OnSceneGUI()
        {
            var path = target as NPatrolPath;
            using (var cc = new EditorGUI.ChangeCheckScope())
            {
                var transform = path.transform;
                var newPositions = path.nodes.SkipLast(1).Select(node =>
                    path.transform.InverseTransformPoint(
                        Handles.PositionHandle(path.transform.TransformPoint(node.position), transform.rotation))).ToList();
                var center = path.nodes.Aggregate(Vector3.zero, (vector3, node) => vector3 + (Vector3) node.position) / path.nodes.Count;
                var mainPosition = Handles.PositionHandle(path.transform.TransformPoint(center), transform.rotation);
                var offset = mainPosition - path.transform.TransformPoint(center);
                
                if (cc.changed) // calling .changed seems to affect state so have to get all position handles at once first
                {
                    for (var i = 0; i < path.nodes.Count - 1; i++)
                    {
                        path.nodes[i].position = newPositions[i] + offset;
                    }

                    if (path.nodes.Count > 0)
                        path.nodes[^1].position = path.nodes[0].position;
                }
            }
        }

        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        static void OnDrawGizmo(NPatrolPath path, GizmoType gizmoType)
        {
            var transform = path.transform;
            for (int i = 0; i < path.nodes.Count - 1; i++)
            {
                var start = path.transform.TransformPoint(path.nodes[i].position);
                var end = path.transform.TransformPoint(path.nodes[i + 1].position);
                Handles.color = Color.yellow;
                Handles.DrawDottedLine(start, end, 5);
                var forward = path.transform.forward;
                Handles.color = Color.blue;
                Handles.DrawSolidDisc(start, forward, 0.1f);
                Handles.Label(start, $"{i} - Pause: {path.nodes[i].pause}");
            }

            var center = path.nodes.Aggregate(Vector3.zero, (vector3, node) => vector3 + (Vector3) node.position) / path.nodes.Count;
            
            Handles.color = Color.red;
            Handles.DrawSolidDisc(path.transform.TransformPoint(center), transform.forward, 0.2f);
        }
    }
}