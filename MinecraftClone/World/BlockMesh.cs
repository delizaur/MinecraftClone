using MinecraftClone.World.Block;
using MinecraftClone.World.States;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World {
    internal class BlockMesh {
        public Vector3 position;

        // the underlying blockstate
        public BlockState blockState;

        public Dictionary<Faces, List<Vector2>> blockUV = new Dictionary<Faces, List<Vector2>>() {
            { Faces.FRONT, new List<Vector2>()},
            { Faces.BACK, new List<Vector2>()},
            { Faces.TOP, new List<Vector2>()},
            { Faces.BOTTOM, new List<Vector2>()},
            { Faces.LEFT, new List<Vector2>()},
            { Faces.RIGHT, new List<Vector2>()},
        };
        public BlockMesh(Vector3 position, BlockState blockState) {
            this.position = position;
            this.blockState = blockState;

            BlockTextureData textureData = blockState.GetBlock().GetTextureData(blockState);
            // sometimes the texture data is null if the block doesn't have to be rendered (such as air)
            if (textureData != null) {
                blockUV = textureData.ToUVs();
            }

            // Console.WriteLine("created a block mesh at " + position + " of type " + this.block.Name());
        }
        public List<Vector3> AddTransformedVertices(List<Vector3> vertices) {
            List<Vector3> transformedVertices = new List<Vector3>();
            foreach (var vert in vertices) {
                transformedVertices.Add(vert + position);
            }
            return transformedVertices;
        }
        public FaceData GetFace(Faces face) {
            return new FaceData {
                vertices = AddTransformedVertices(FaceDataRaw.rawVertexData[face]),
                uv = blockUV[face],
            };
        }
    }
}
