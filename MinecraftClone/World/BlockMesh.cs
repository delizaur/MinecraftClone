using MinecraftClone.World.Block;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World {
    internal class BlockMesh {
        public Vector3 position;

        // the underlying block
        public BaseBlock block;

        public Dictionary<Faces, FaceData> faces;

        public Dictionary<Faces, List<Vector2>> blockUV = new Dictionary<Faces, List<Vector2>>() {
            { Faces.FRONT, new List<Vector2>()},
            { Faces.BACK, new List<Vector2>()},
            { Faces.TOP, new List<Vector2>()},
            { Faces.BOTTOM, new List<Vector2>()},
            { Faces.LEFT, new List<Vector2>()},
            { Faces.RIGHT, new List<Vector2>()},
        };
        public BlockMesh(Vector3 position, BaseBlock block) {
            this.position = position;
            this.block = block;

            if (!(this.block is AirBlock)) {
                blockUV = block.GetTextureData().ToUVs();
            }

            // Console.WriteLine("created a block mesh at " + position + " of type " + this.block.Name());

            faces = new Dictionary<Faces, FaceData>
            {
                {Faces.FRONT, new FaceData {
                    vertices = AddTransformedVertices(FaceDataRaw.rawVertexData[Faces.FRONT]),
                    uv = blockUV[Faces.FRONT]
                } },
                {Faces.BACK, new FaceData {
                    vertices = AddTransformedVertices(FaceDataRaw.rawVertexData[Faces.BACK]),
                    uv = blockUV[Faces.BACK]
                } },
                {Faces.LEFT, new FaceData {
                    vertices = AddTransformedVertices(FaceDataRaw.rawVertexData[Faces.LEFT]),
                    uv = blockUV[Faces.LEFT]
                } },
                {Faces.RIGHT, new FaceData {
                    vertices = AddTransformedVertices(FaceDataRaw.rawVertexData[Faces.RIGHT]),
                    uv = blockUV[Faces.RIGHT]
                } },
                {Faces.TOP, new FaceData {
                    vertices = AddTransformedVertices(FaceDataRaw.rawVertexData[Faces.TOP]),
                    uv = blockUV[Faces.TOP]
                } },
                {Faces.BOTTOM, new FaceData {
                    vertices = AddTransformedVertices(FaceDataRaw.rawVertexData[Faces.BOTTOM]),
                    uv = blockUV[Faces.BOTTOM]
                } },

            };
        }
        public List<Vector3> AddTransformedVertices(List<Vector3> vertices) {
            List<Vector3> transformedVertices = new List<Vector3>();
            foreach (var vert in vertices) {
                transformedVertices.Add(vert + position);
            }
            return transformedVertices;
        }
        public FaceData GetFace(Faces face) {
            return faces[face];
        }
    }
}
