using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public T PropertyValue
        {
            get
            {
                var propertyInfo = GetPropertyInfo();
                if(propertyInfo == null)
                {
                    return default(T);
                }
                return (T)propertyInfo.GetValue(Entity);
            }
            set
            {
                GetPropertyInfo()?.SetValue(Entity, value);
            }
        }

        private PropertyInfo propertyInfo;
        private PropertyInfo GetPropertyInfo()
        {
            if (string.IsNullOrWhiteSpace(PropertyName) || Entity == null)
            {
                throw new ArgumentException("PropertyName 或 Entity 不能为空");
            }
            try
            {
                propertyInfo = propertyInfo ?? Entity.GetType().GetProperty(PropertyName);
            }
            catch (Exception ex)
            {
                throw new Exception("无法获取属性：" + PropertyName + "，在类型：" + Entity.GetType().ToString() + "中。 详细见内部异常。", ex);
            }
            return propertyInfo;
            
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

    public static class ObjectExtend
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
