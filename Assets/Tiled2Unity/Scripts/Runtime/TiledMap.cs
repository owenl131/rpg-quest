using UnityEngine;

namespace Tiled2Unity
{
    public class TiledMap : MonoBehaviour
    {
        public float ExportScale = 1.0f;
        public int MapHeightInPixels = 0;
        // Note: Because maps can be isometric and staggered we simply can't multply tile width (or height) by number of tiles wide (or high) to get width (or height)
        // We rely on the exporter to calculate the width and height of the map
        public int MapWidthInPixels = 0;
        public int NumTilesHigh = 0;
        public int NumTilesWide = 0;
        public int TileHeight = 0;
        public int TileWidth = 0;

        public float GetMapWidthInPixelsScaled()
        {
            return MapWidthInPixels*transform.lossyScale.x*ExportScale;
        }

        public float GetMapHeightInPixelsScaled()
        {
            return MapHeightInPixels*transform.lossyScale.y*ExportScale;
        }

        private void OnDrawGizmosSelected()
        {
            Vector2 pos_w = gameObject.transform.position;
            var topLeft = Vector2.zero + pos_w;
            var topRight = new Vector2(GetMapWidthInPixelsScaled(), 0) + pos_w;
            var bottomRight = new Vector2(GetMapWidthInPixelsScaled(), -GetMapHeightInPixelsScaled()) + pos_w;
            var bottomLeft = new Vector2(0, -GetMapHeightInPixelsScaled()) + pos_w;

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(topLeft, topRight);
            Gizmos.DrawLine(topRight, bottomRight);
            Gizmos.DrawLine(bottomRight, bottomLeft);
            Gizmos.DrawLine(bottomLeft, topLeft);
        }
    }
}