using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static Service.Core.EnumData;

namespace Service.Core.MQ
{
    public abstract class MQBase
    {
        protected Dictionary<ActionType, Action<ActionType, string, string, string[]>> Actions;
        protected string HostName;
        protected string QueueName;
        public abstract MQBase CreateConsumer(Dictionary<ActionType, Action<ActionType, string, string, string[]>> actions);
        public abstract MQBase CreateProducer();
        public static MQBase CreateInstance(string queueType, string hostName, string queueName)
        {
            Type type = Assembly.GetAssembly(typeof(MQBase)).GetTypes().Where(t => t.Name.ToUpper().Equals(queueType.ToUpper())).FirstOrDefault();

            return (MQBase)Activator.CreateInstance(type, new object[] { hostName, queueName });
        }
    }
}
