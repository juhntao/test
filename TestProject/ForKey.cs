using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class ForKey<T>
    {
        public ForKey(TableType forKeyTableType, string forKeyPropertyName, IEntity currentEntity)
        {
            this.EntityType = forKeyTableType;
            this.PropertyName = forKeyPropertyName;
            this.Entity = currentEntity;
        }

        public TableType EntityType { get; set; }

        public string PropertyName { get; set; }

        public IEntity Entity { get; set; }

        public T GetPropertyValue()
        {
            try
            {
                return (T)Entity.GetType().GetProperty(PropertyName).GetValue(Entity);
            }
            catch (Exception ex)
            {
                throw new Exception("无法获取属性：" + PropertyName + "，在类型：" + Entity.GetType().ToString() + "中。 详细见内部异常。", ex);
            }
        }
        public void SetPropertyValue(T tid)
        {
            try
            {
                Entity.GetType().GetProperty(PropertyName).SetValue(Entity, tid);
            }
            catch (Exception ex)
            {
                throw new Exception("无法获取属性：" + PropertyName + "，在类型：" + Entity.GetType().ToString() + "中。 详细见内部异常。", ex);
            }
        }
    }

    public enum TableType
    {
        Default
    }

    public interface IEntity
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime CreatedOn { get; set; }
    }

    public class Entity : IEntity
    {
        public int Id { get;set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public static class ObjctExtend
    {
        public static string ToStringOrNull(this object data)
        {
            if (data == null)
            {
                return null;
            }
            return data.ToString();
        }
    }
}
