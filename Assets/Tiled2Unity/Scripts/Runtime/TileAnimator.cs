using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiled2Unity
{
    public class TileAnimator : MonoBehaviour
    {
        private int currentFrameIndex;
        public List<Frame> frames = new List<Frame>();

        private void Start()
        {
            currentFrameIndex = 0;

            if (frames.Count == 0)
            {
                Debug.LogError(string.Format("TileAnimation on '{0}' has no frames.", name));
            }
            else
            {
                StartCoroutine(AnimationRoutine());
            }
        }

        private IEnumerator AnimationRoutine()
        {
            while (true)
            {
                var frame = frames[currentFrameIndex];

                // Make the frame 'visible' by making negative 'z' vertex positions positive
                ModifyVertices(-frame.Vertex_z);

                // Wait until the next frame
                var timeToWait = frame.DurationMs/1000.0f;
                yield return new WaitForSeconds(timeToWait);

                // Make the frame 'invisible' again. Make matching positive 'z' values negative
                ModifyVertices(frame.Vertex_z);

                // Go to the next frame
                currentFrameIndex = (currentFrameIndex + 1)%frames.Count;
            }
        }

        // Find 'z' values on vertices that match and negate them
        private void ModifyVertices(float z)
        {
            var negated = -z;

            // Because meshes may be split we have to go over all them in our tree
            var meshFilters = GetComponentsInChildren<MeshFilter>();
            foreach (var mf in meshFilters)
            {
                var vertices = mf.mesh.vertices;
                for (var i = 0; i < vertices.Length; ++i)
                {
                    if (vertices[i].z == z)
                    {
                        vertices[i].z = negated;
                    }
                }

                // Save the vertices back
                mf.mesh.vertices = vertices;
            }
        }

        [Serializable]
        public class Frame
        {
            public int DurationMs = 0;
            public float Vertex_z = 0;
        }
    }
}