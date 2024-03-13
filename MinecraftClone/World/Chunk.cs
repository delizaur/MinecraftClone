using MinecraftClone.World.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World {
    internal class Chunk {

        public static readonly int SIZE = 16;
        public static readonly int HEIGHT = 32;

        private BaseBlock[,,] blocks = new BaseBlock[SIZE, HEIGHT, SIZE];
        public int[,] heightmap = new int[SIZE, SIZE];

        public int worldX;
        public int worldZ;

        public Chunk(int worldX, int worldZ) {
            this.worldX = worldX;
            this.worldZ = worldZ;
            for (int x = 0; x < SIZE; x++) {
                for (int z = 0; z < SIZE; z++) {
                    for (int y = 0;  y < HEIGHT; y++) {
                        blocks[x, y, z] = Blocks.AIR;
                    }
                }
            }
        }

        public void SetBlock(int chunkX, int chunkY, int chunkZ, BaseBlock block) {
            // TODO: Handle updating the heightmap when removing a block (ie placing air)
            if (block is not AirBlock && chunkY > heightmap[chunkX, chunkZ]) {
                heightmap[chunkX, chunkZ] = chunkY;
            }
            blocks[chunkX, chunkY, chunkZ] = block;
        }

        public BaseBlock GetBlock(int x, int y, int z) {
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
