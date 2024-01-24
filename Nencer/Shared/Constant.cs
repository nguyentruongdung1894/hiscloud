namespace Nencer.Shared
{
    public class Constant
    {
        public enum Status
        {
            PENDING = 1,
            PROCESSING = 2,
            CANCELLED = 3,
            FINISHED = 4,
        }
        public enum Calling
        {
            CALLED = 1,
            WAITING = 2,
        }
        public enum ExamOrderStatus
        {
            PAID = 1,
            UNPAID = 2,
        }
        public enum ExamStatus // 
        {
            PENDING = 1,
            PROCESSING = 2,
            CANCELLED = 3,
            FINISHED = 4,
        }
        public enum ExamTicketStatus // 
        {
            ACTIVE = 1,
            INACTIVE = 2,
            DELETE = 3,
        }
        public enum ServiceObjectType
        {
            INSURANCE = 1,
            MEDICAL_FEE = 2,
            REQUEST = 3,
            FREE = 4,
        }
        public enum PatialType
        {
            INSURANCE = 1,
            MEDICAL_FEE = 2,
            REQUEST = 3,
            FREE = 4,
        }
        public enum OrdinalDoor
        {
            UT = 1,
            ST = 2
        }
    }
}
