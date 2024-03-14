using MinecraftClone.World.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World.Block {
    internal class DirtBlock : BaseBlock {

        public override BlockTextureData GetTextureData(BlockState state) {
            var dirt = (2, 15);
            return new BlockTextureData() {
                top = dirt,
                bottom = dirt,
                left = dirt,
                right = dirt,
                front = dirt,
                back = dirt,
            };
        }

        public override string Name() {
            return "dirt";
        }
    }
}
