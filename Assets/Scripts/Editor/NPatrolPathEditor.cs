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
                var newPositions = path.nodes.Select(node =>
                    path.transform.InverseTransformPoint(
                        Handles.PositionHandle(path.transform.TransformPoint(node.position), path.transform.rotation))).ToList();
                if (cc.changed) // calling .changed seems to affect state so have to get all position handles at once first
                {
                    for (var i = 0; i < path.nodes.Count; i++)
                    {
                        path.nodes[i].position = newPositions[i];
                    }
                }
            }
        }

        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        static void OnDrawGizmo(NPatrolPath path, GizmoType gizmoType)
        {
            for (int i = 0; i < path.nodes.Count - 1; i++)
            {
                var start = path.transform.TransformPoint(path.nodes[i].position);
                var end = path.transform.TransformPoint(path.nodes[i + 1].position);
                Handles.color = Color.yellow;
                Handles.DrawDottedLine(start, end, 5);
                var forward = path.transform.forward;
                Handles.DrawSolidDisc(start, forward, 0.1f);
                Handles.DrawSolidDisc(end, forward, 0.1f);
            }
        }
    }
}