using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World {
    internal class ChunkGenerator {

        private static Random rng = new Random();
        public Chunk GenerateChunk(int worldX, int worldZ) {
            Console.WriteLine("Generating chunk at pos " + worldX + ", " + worldZ);
            Chunk chunk = new Chunk(worldX, worldZ);
            SimplexNoise.Noise.Seed = 1;
            for (int x = 0; x < Chunk.SIZE; x++) {
                for (int z = 0; z < Chunk.SIZE; z++) {
                    
                    int columnHeight = (int)(SimplexNoise.Noise.CalcPixel2D(x + worldX, z + worldZ, 0.01f) / 10f);
                    
                    Debug.Assert(columnHeight < Chunk.HEIGHT);

                    chunk.SetBlock(x, columnHeight, z, Blocks.GRASS);
                    for (int y = 0; y < columnHeight; y++) {
                        chunk.SetBlock(x, y, z, Blocks.DIRT);
                    }

                    // tree trunk generation
                    if (rng.Next(30) == 0) {
                        chunk.SetBlock(x, columnHeight + 1, z, Blocks.LOG);
                        chunk.SetBlock(x, columnHeight + 2, z, Blocks.LOG);
                        chunk.SetBlock(x, columnHeight + 3, z, Blocks.LOG);
                    }
                }
            }
            chunk.SetBlock(4, 25, 4, Blocks.GRASS);
            return chunk;
        }
    }
}
