using MinecraftClone.Graphics;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftClone;
using static OpenTK.Graphics.OpenGL.GL;
using MinecraftClone.World.Block;
using System.Data.Common;

namespace MinecraftClone.World {
    internal class ChunkMesh {
        public List<Vector3> chunkVerts;
        public List<Vector2> chunkUVs;
        public List<uint> chunkIndices;

        public Vector3 position;

        public uint indexCount;

        VAO chunkVAO;
        VBO chunkVertexVBO;
        VBO chunkUVVBO;
        IBO chunkIBO;

        Texture texture;

        
        

        // the underlying chunk. from here we can get the block types at every pos
        Chunk chunk;
        public ChunkMesh(Chunk chunk) {
            this.position = new Vector3(chunk.worldX, 0, chunk.worldZ);
            this.chunk = chunk;

            chunkVerts = new List<Vector3>();
            chunkUVs = new List<Vector2>();
            chunkIndices = new List<uint>();

            
            float[,] heightMap = GenChunk();
            GenBlocks();
            GenFaces();
            BuildChunk();
        }

        // TODO: Move this into the ChunkProvider class
        public float[,] GenChunk() { // generate the data
            float[,] heightmap = new float[Chunk.SIZE, Chunk.SIZE];

            SimplexNoise.Noise.Seed = 1;
            for (int x = 0; x < Chunk.SIZE; x++) {
                for (int z = 0; z < Chunk.SIZE; z++) {
                    heightmap[x, z] = SimplexNoise.Noise.CalcPixel2D(x, z, 0.01f);
                }
            }

            return heightmap;
        } 

        // fills the chunkBlocks array with the Block Meshes
        public void GenBlocks() {
            
            for (int x = 0; x < Chunk.SIZE; x++) {
                for (int z = 0; z < Chunk.SIZE; z++) {
                    // removed heightmap optimization because skill issue
                    // int columnHeight = this.chunk.heightmap[x, z];
                    for (int y = 0; y < Chunk.HEIGHT; y++) {
                        // chunkBlocks[x, y, z] = new BlockMesh(new Vector3(x + position.X, y + position.Y, z + position.Z), this.chunk.GetBlock(x, y, z));
                    }
                }
            }            
        } 

        public BlockMesh GetMeshAt(int x, int y, int z) {
            return new BlockMesh(new Vector3(x + position.X, y + position.Y, z + position.Z), this.chunk.GetBlock(x, y, z));
        }

        // generate the appropiate block faces given the data
        public void GenFaces() {
            for (int x = 0; x < Chunk.SIZE; x++) {
                for (int z = 0; z < Chunk.SIZE; z++) {
                    int columnHeight = this.chunk.heightmap[x, z] + 1; // uhh this +1 shouldn't be here but idk how to properly fix it
                    for (int y = 0; y < columnHeight; y++) {

                        // this shitty hack actually works LMAO
                        if (chunk.GetBlock(x, y, z) is AirBlock) continue;
                        
                        BlockMesh currMesh = this.GetMeshAt(x, y, z);

                        // left faces
                        // qualifications for left faces: block to left is empty, is farthest left in chunk
                        int numFaces = 0;
                        if (x > 0) {
                            if (chunk.GetBlock(x-1, y, z) is AirBlock) {
                               
                                IntegrateFace(currMesh, Faces.LEFT);
                                numFaces++;
                            }
                        } else {
                            IntegrateFace(currMesh, Faces.LEFT);
                            numFaces++;
                        }
                        

                        // right faces
                        // qualifications: block to right is emmpty, is farthest right in chunk
                        if (x < Chunk.SIZE-1) {
                            if (chunk.GetBlock(x + 1, y, z) is AirBlock) {

                                IntegrateFace(currMesh, Faces.RIGHT);
                                numFaces++;
                            }
                        } else {
                            IntegrateFace(currMesh, Faces.RIGHT);
                            numFaces++;
                        }

                        // top faces
                        // qualifications: block above is emmpty, is farthest up in chunk
                        if (y < columnHeight - 1) {
                            if (chunk.GetBlock(x, y+1, z) is AirBlock) {
                                IntegrateFace(GetMeshAt(x, y, z), Faces.TOP);
                                numFaces++;
                            }
                        } else {
                            IntegrateFace(currMesh, Faces.TOP);
                            numFaces++;
                        }

                        // bottom faces
                        // qualifications: block below is emmpty, is farthest down in chunk
                        if (y > 0) {
                            if (chunk.GetBlock(x, y - 1, z) is AirBlock) {
                                IntegrateFace(currMesh, Faces.BOTTOM);
                                numFaces++;
                            }
                        } else {
                            IntegrateFace(currMesh, Faces.BOTTOM);
                            numFaces++;
                        }

                        // front faces
                        if (z < Chunk.SIZE-1) {
                            if (chunk.GetBlock(x, y, z + 1) is AirBlock) {
                                IntegrateFace(currMesh, Faces.FRONT);
                                numFaces++;
                            }
                        } else {
                            IntegrateFace(GetMeshAt(x, y, z), Faces.FRONT);
                            numFaces++;
                        }

                        // back faces
                        if (z > 0) {
                            if (chunk.GetBlock(x, y, z - 1) is AirBlock) {
                                IntegrateFace(currMesh, Faces.BACK);
                                numFaces++;
                            }
                        } else {
                            IntegrateFace(currMesh, Faces.BACK);
                            numFaces++;
                        }

                        AddIndices(numFaces);
                    }
                }
            }
        }
        
        public void IntegrateFace(BlockMesh block, Faces face) {
            var faceData = block.GetFace(face);
            chunkVerts.AddRange(faceData.vertices);
            chunkUVs.AddRange(faceData.uv);
        }
        
        // generate the appropriate block faces given the data
        public void AddIndices(int amtFaces) {
            for (int i = 0; i < amtFaces; i++) {
                chunkIndices.Add(0 + indexCount);
                chunkIndices.Add(1 + indexCount);
                chunkIndices.Add(2 + indexCount);
                chunkIndices.Add(2 + indexCount);
                chunkIndices.Add(3 + indexCount);
                chunkIndices.Add(0 + indexCount);

                indexCount += 4;
            }
        }
        public void BuildChunk() {
            chunkVAO = new VAO();
            chunkVAO.Bind();

            chunkVertexVBO = new VBO(chunkVerts);
            chunkVertexVBO.Bind();
            chunkVAO.LinkToVAO(0, 3, chunkVertexVBO);

            chunkUVVBO = new VBO(chunkUVs);
            chunkUVVBO.Bind();
            chunkVAO.LinkToVAO(1, 2, chunkUVVBO);

            chunkIBO = new IBO(chunkIndices);

            texture = new Texture("atlas.png");
        } // take data and process it for rendering
        public void Render(ShaderProgram program) // drawing the chunk
        {
            program.Bind();
            chunkVAO.Bind();
            chunkIBO.Bind();
            texture.Bind();
            GL.DrawElements(PrimitiveType.Triangles, chunkIndices.Count, DrawElementsType.UnsignedInt, 0);
        }

        public void Delete() {
            chunkVAO.Delete();
            chunkVertexVBO.Delete();
            chunkUVVBO.Delete();
            chunkIBO.Delete();
            texture.Delete();
        }
    }
}
