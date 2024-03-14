using MinecraftClone.World.Block;
using MinecraftClone.World.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World {
    internal class Chunk {

        public static readonly int SIZE = 16;
        public static readonly int HEIGHT = 32;

        // for now the chunk will contain references to blockstate (8 bytes), in the future this could be optimized
        // to use stateIDs instead (2 bytes maybe)
        // still, for a 16x16x256 chunk it's 0.5 MB so not too bad. 
        private BlockState[,,] blocks = new BlockState[SIZE, HEIGHT, SIZE];
        public int[,] heightmap = new int[SIZE, SIZE];

        public int worldX;
        public int worldZ;

        public Chunk(int worldX, int worldZ) {
            this.worldX = worldX;
            this.worldZ = worldZ;
            for (int x = 0; x < SIZE; x++) {
                for (int z = 0; z < SIZE; z++) {
                    for (int y = 0;  y < HEIGHT; y++) {
                        blocks[x, y, z] = new BlockState(Blocks.AIR, Blocks.AIR.GetDefaultState());
                    }
                }
            }
        }

        public S? GetStateAs<S>(int chunkX, int chunkY, int chunkZ) where S : State, new() {
            var blockState = blocks[chunkX, chunkY, chunkZ];
            // this check could be skipped in an "unchecked" variant. 
            if (blockState.GetBlock().GetDefaultState() is not S) {
                return null;
            }
            // this is safe because of the previous check
            return blockState.GetStateAs<S>();
        }

        public void SetBlock(int chunkX, int chunkY, int chunkZ, BaseBlock block) {
            // TODO: Handle updating the heightmap when removing a block (ie placing air)
            if (block is not AirBlock && chunkY > heightmap[chunkX, chunkZ]) {
                heightmap[chunkX, chunkZ] = chunkY;
            }
            blocks[chunkX, chunkY, chunkZ] = new BlockState(block);
        }

        public void SetBlockState(int chunkX, int chunkY, int chunkZ, BlockState blockState) {
            // TODO: Handle updating the heightmap when removing a block (ie placing air)
            if (blockState.GetBlock() is not AirBlock && chunkY > heightmap[chunkX, chunkZ]) {
                heightmap[chunkX, chunkZ] = chunkY;
            }
            blocks[chunkX, chunkY, chunkZ] = blockState;
        }

        public BaseBlock GetBlock(int x, int y, int z) {
            return blocks[x, y, z].GetBlock();
        }

        public BlockState GetBlockState(int x, int y, int z) {
            return blocks[x, y, z];
        }

        public void PrintHeightMap() {
            for (int x = 0; x < SIZE; x++) {
                for (int z = 0; z < SIZE; z++) {
                    Console.Write(heightmap[x, z] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
