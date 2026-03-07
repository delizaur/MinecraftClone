using MinecraftClone.World.States;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World.Block {
    internal class LampBlock : BaseBlock {

        public override string Name() {
            return "lamp";
        }

        public override BlockTextureData GetTextureData(BlockState state) {
            bool isOn = state.GetStateAs<LampState>().powered;
            var texture = isOn ? (8, 7) : (8, 8);
            return new BlockTextureData() {
                top = texture,
                bottom = texture,
                left = texture,
                right = texture,
                front = texture,
                back = texture,
            };
        }

        public override void OnRightClick(MinecraftWorld world, BlockState state, Vector3i pos) {
            var next = state.GetAs<LampState>();
            next.state.powered = !next.state.powered;
            world.SetBlockState(pos, next);
        }

        public class LampState : State {
            public bool powered;
            public override short Serialize() {
                return (short)(powered ? 1 : 0);
                // return StateBuilder.Serialize(powered);
            }

            public override State Deserialize(short serialized) {
                return new LampState {
                    powered = serialized == 1,
                };
                // return StateBuilder.Deserialize<BoolProperty>(serialized, powered => new LampState { powered = powered });
            }
        }
    }
}
