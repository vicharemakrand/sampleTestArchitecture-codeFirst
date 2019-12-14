namespace MV.Prometric.EntityModels
{
    public partial class Vehicle : BaseEntity
    {
        public string ModelName { get; set; }
        public string Color { get; set; }
        public decimal MpgValue { get; set; }
    }
}
