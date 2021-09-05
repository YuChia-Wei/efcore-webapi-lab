using System;

#nullable disable

namespace LabWebApi.Repository.Entities
{
    public partial class DbFirstTable
    {
        public int MainId { get; set; }
        public string MainData { get; set; }
        public decimal? AmountField { get; set; }
        public DateTime? DateTimeField { get; set; }
        public int? SubId { get; set; }

        public virtual SubTable Sub { get; set; }
    }
}