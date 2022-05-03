using Newtonsoft.Json;
using System;

namespace Common
{
    public class ConvertTo
    {
        public static TTarget Convert<TSource, TTarget>(TSource sourceItem)
        {
            if (null == sourceItem)
            {
                return default(TTarget);
            }

            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace, };

            var serializedObject = JsonConvert.SerializeObject(sourceItem, deserializeSettings);

            return JsonConvert.DeserializeObject<TTarget>(serializedObject);
        }
    }
}
