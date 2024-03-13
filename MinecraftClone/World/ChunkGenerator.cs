using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World {
    internal class ChunkGenerator {
        public Chunk GenerateChunk(int worldX, int worldZ) {
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
                }
            }
            chunk.SetBlock(4, 25, 4, Blocks.GRASS);
            return chunk;
        }
    }
}
