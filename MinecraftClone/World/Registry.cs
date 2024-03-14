using OpenTK.Graphics.ES11;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World {
    internal class Registry<T> where T : RegistryObject {

        List<T> objects = new List<T>();
        Dictionary<string, int> namesToIndices = new Dictionary<string, int>();

        public SubT Register2<SubT>(string name, SubT obj) where SubT : T {
            int index = objects.Count;
            objects.Add(obj);
            obj.SetId((short)index);
            namesToIndices.Add(name, index);
            return obj;
        }

        public T GetByName(string name) {
            // TODO: What if the name isn't found??
            int index = namesToIndices[name];
            return objects[index];
        }

        public T GetById(int id) {
            return objects[id];
        }

    }
}
