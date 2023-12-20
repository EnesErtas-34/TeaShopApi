namespace TeaShopApi.WebUI.Dtos.MessageDtos
{
    public class ResultMessageDto
    {
        public int MessageID { get; set; }
        public string MessageSenderName { get; set; }
        public string MessageSubject { get; set; }
        public string MessageEmail { get; set; }
        public string MessageDetail { get; set; }
        public DateTime MessageSendDate { get; set; }
    }
}
