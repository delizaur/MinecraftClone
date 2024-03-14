using MinecraftClone.World.Block;
using MinecraftClone.World.States;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World {

    

    internal class MinecraftWorld {
        private static ChunkGenerator generator = new ChunkGenerator();

        private List<Chunk> chunks = new List<Chunk>();

        public void GenerateChunksInArea(int chunkCount) {
            for (int x = 0; x < chunkCount; x++) {
                for (int z = 0; z < chunkCount; z++) {
                    Console.WriteLine("Generating chunk at position x=" + x * 16 + " z=" + z * 16);
                    chunks.Add(generator.GenerateChunk(x, z));
                }
            }
        }

        public List<Chunk> GetChunks() {
            return chunks;
        }

        // set a block. the state will be the block's default state
        public void SetBlock(int x, int y, int z, BaseBlock block) {
            throw new NotImplementedException();
        }

        public void SetBlock(Vector3i pos, BaseBlock block) {
            SetBlock(pos.X, pos.Y, pos.Z, block);
        }

        public S GetStateAs<S>(Vector3i pos) {
            throw new NotImplementedException();
        }

        public void SetBlockState(Vector3i pos, BlockState blockState) {
            throw new NotImplementedException();
        }

    }
}
