using MinecraftClone.World.Block;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World.States
{
    internal struct BlockState
    {

        private short blockID;
        private short serializedState;

        // construct a block state from a block reference and deserialized state
        // caller must enforce that the state passed in corresponds to the block's state
        public BlockState(BaseBlock block, State state) {
            Debug.Assert(block.GetDefaultState().GetType() == state.GetType());
            this.blockID = block.GetId();
            this.serializedState = state.Serialize();
        }

        // construct a new block state with the block's default state
        public BlockState(BaseBlock block) {
            this.blockID = block.GetId();
            this.serializedState = block.GetDefaultState().Serialize();
        }

        /* Idea: forget about creating every possible blockstate at the start and making the world store references to that
         * instead, just make the world a collection of blockstates (structs, not references) where we store the blockId (short)
         * and the serialized state (short). this is way simpler but potentially less type safe
         * 
         */

        public S GetStateAs<S>() where S: State, new() {
            Debug.Assert(this.GetBlock().GetDefaultState() is S);
            return (S)new S().Deserialize(serializedState);
        }

        // caller must ensure that S corresponds to the state type of this blockstate's block
        public DeserializedBlockState<S> GetAs<S>() where S: State, new() {
            return new DeserializedBlockState<S>(this.GetBlock(), this.GetStateAs<S>());
        }

        public void SetState<S>(S state) where S: State {
            Debug.Assert(this.GetBlock().GetDefaultState() is S);
            serializedState = state.Serialize();
        }

        public BaseBlock GetBlock() {
            return Blocks.blockRegistry.GetById(blockID);
        }
    }
}
