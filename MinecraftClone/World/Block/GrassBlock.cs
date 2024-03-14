using MinecraftClone.World.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World.Block {
    internal class GrassBlock : BaseBlock {

        public override BlockTextureData GetTextureData(BlockState state) {
            var topFace = (7, 13);
            var sideFace = (3, 15);
            var bottomFace = (2, 15);
            return new BlockTextureData() {
                top = topFace,
                bottom = bottomFace,
                left = sideFace,
                right = sideFace,
                front = sideFace,
                back = sideFace,
            };
        }

        public override string Name() {
            return "grass";
        }

    }
}
