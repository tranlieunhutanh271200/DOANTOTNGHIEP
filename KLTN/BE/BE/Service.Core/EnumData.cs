namespace Service.Core
{
    public class EnumData
    {
        public enum Channel
        {

        }
        public enum QueueType
        {
            MSMQ,
            ActiveMQ
        }
        public enum ActionType
        {
            SendRequest,
            SendResponse
        }
    }
}
