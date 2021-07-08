using System;

#nullable disable

namespace LabWebApi.Repository.Entities
{
    public partial class DbFirstTable
    {
        public int Id { get; set; }
        public DateTime? DateTimeField { get; set; }
        public decimal? AmountField { get; set; }
        public string StringField { get; set; }
    }
}
