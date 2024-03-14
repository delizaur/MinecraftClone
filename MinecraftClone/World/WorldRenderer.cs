using MinecraftClone.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World {
    internal class WorldRenderer {

        private MinecraftWorld world;

        private Dictionary<(int, int), ChunkMesh> chunkMeshes = new Dictionary<(int, int), ChunkMesh>();

        private ShaderProgram shader;

        public WorldRenderer(MinecraftWorld world) {
            shader = new ShaderProgram("Default.vert", "Default.frag");
            this.world = world; 
        }

        public void BuildAllMeshes() {
            throw new NotImplementedException();
        }

        public void UnloadAll() {
            foreach (ChunkMesh chunk in chunkMeshes.Values) {
                chunk.Delete();
            }
        }

        

    }
}
