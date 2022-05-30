using System;
using System.Data;

namespace BookstoreManagement.DTO
{
    public class DebtNote
    {
        private string _id;
        private string _customerId;
        private string _date;
        private string _paid;

        public DebtNote(DataRow row)
        {
            this.Id = row["MaPTTN"].ToString();
            this.CustomerId = row["MaKH"].ToString();
            this.Date = row["NgayLap"].ToString();
            this.Paid = row["TienThu"].ToString();
        }

        public string Id { get => _id; set => _id = value; }
        public string CustomerId { get => _customerId; set => _customerId = value; }
        public string Date { get => _date; set => _date = value; }
        public string Paid { get => _paid; set => _paid = value; }
    }
}
