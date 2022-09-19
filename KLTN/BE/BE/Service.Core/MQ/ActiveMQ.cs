using System;
using System.Collections.Generic;

namespace Service.Core.MQ
{
    public class ActiveMQ : MQBase
    {
        public ActiveMQ(string hostName, string queueName)
        {

        }

        public override MQBase CreateConsumer(Dictionary<EnumData.ActionType, Action<EnumData.ActionType, string, string, string[]>> actions)
        {
            throw new NotImplementedException();
        }

        public override MQBase CreateProducer()
        {
            throw new NotImplementedException();
        }
    }
}
