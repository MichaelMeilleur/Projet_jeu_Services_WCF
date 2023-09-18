namespace ServiceWFC_HugoWorld.DTO
{
    [DataContract]
    public class MondeDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int x { get; set; }
        [DataMember]
        public int y { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int TypeObjet { get; set; }
        [DataMember]
        public int MondeId { get; set; }
    }
}
