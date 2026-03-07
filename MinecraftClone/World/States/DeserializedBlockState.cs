using MinecraftClone.World.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World.States {
    internal class DeserializedBlockState<S> where S : State {
        public BaseBlock block;
        public S state;

        public DeserializedBlockState(BaseBlock block, S state) {
            this.block = block;
            this.state = state;
        }

        public static implicit operator BlockState(DeserializedBlockState<S> wrapper) {
            return new BlockState(wrapper.block, wrapper.state);
        }
    }
}
