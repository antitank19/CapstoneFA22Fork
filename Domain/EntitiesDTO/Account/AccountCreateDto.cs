using Domain.EntitiesForManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EntitiesDTO
{
    public class AccountCreateDto
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<ExpenseGetDto> Expenses { get; set; }
        public virtual ICollection<InvoiceGetDto> Invoices { get; set; }
    }
}
