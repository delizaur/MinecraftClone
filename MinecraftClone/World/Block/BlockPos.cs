using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World.Block {



    internal struct BlockPos {
        private Vector3i position;

        public Vector3i AsChunkLocalCoords() {
            return new Vector3i(position.X % Chunk.SIZE, position.Y % Chunk.HEIGHT, position.Z % Chunk.SIZE);
        }

        // assumption: chunks are 16x16x256
        // packed as ZZZZYYYYYYYYXXXX
        public static short Pack(BlockPos pos) {
            var chunkCoords = pos.AsChunkLocalCoords();
            int x = chunkCoords.X;
            int y = chunkCoords.Y << 4;
            int z = chunkCoords.Z << 12;
            return (short)(x | y | z);
        }

        // RETURNS CHUNK LOCAL COORDS
        public static Vector3i Unpack(short packed) {
            int x =  packed & 0b0000000000001111;
            int y = (packed & 0b0000111111110000) >> 4;
            int z = (packed & 0b1111000000000000) >> 12;
            return new Vector3i(x, y, z);
        }
    }
}
