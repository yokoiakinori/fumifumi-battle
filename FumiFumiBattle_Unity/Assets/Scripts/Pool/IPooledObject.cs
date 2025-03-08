using UnityEngine.Pool;

namespace Pool
{
    public interface IPooledObject<T> where T : class
    {
        public IObjectPool<T> ObjectPool { set; }
        public void Initialize();
        public void Deactivate();
    }
}