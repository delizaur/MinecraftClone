using MinecraftClone.World.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World.States {
    internal class BlockStateWrapper<S> where S : State {
        public BaseBlock block;
        public S state;

        public BlockStateWrapper(BaseBlock block, S state) {
            this.block = block;
            this.state = state;
        }

        public static implicit operator BlockState(BlockStateWrapper<S> wrapper) {
            return new BlockState(wrapper.block, wrapper.state);
        }
    }
}
