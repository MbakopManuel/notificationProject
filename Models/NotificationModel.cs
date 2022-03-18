namespace Models
{
    public class NotificationModel{
        public string id {get; set;}
        public string userId {get; set;}
        public string groupId {get; set;}
        public string offerId {get; set;}
        public string companyId {get; set;}
        public string subject {get; set;}
        public string link {get; set;}
        public string uid {get; set;}
        public int groupNotification {get; set;}
        public int activityNotification {get; set;}
        public int chatNotification {get; set;}
        public int partnershipNotification {get; set;}
        public int generalNotification {get; set;}
        public string enumNotifState  {get; set;}
        public string enumNotifType  {get; set;}
    }
}