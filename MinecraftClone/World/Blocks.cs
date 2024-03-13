
using MinecraftClone.World.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World
{
    internal class Blocks {
        public static Registry<BaseBlock> blockRegistry = new Registry<BaseBlock>();
        /*
        public static readonly RegistryObject<AirBlock> AIR = blockRegistry.Register("block.air", new AirBlock());
        public static readonly RegistryObject<GrassBlock> GRASS = blockRegistry.Register("block.grass", new GrassBlock());
        public static readonly RegistryObject<DirtBlock> DIRT = blockRegistry.Register("block.dirt", new DirtBlock());
        */
        public static readonly AirBlock AIR = blockRegistry.Register2("block.air", new AirBlock());
        public static readonly GrassBlock GRASS = blockRegistry.Register2("block.grass", new GrassBlock());
        public static readonly DirtBlock DIRT = blockRegistry.Register2("block.dirt", new DirtBlock());
    }
}
