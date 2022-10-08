using Domain.EntitiesDTO.Expense;
using Domain.EntitiesDTO.Invoice;
using Domain.EntitiesDTO.Role;

namespace Domain.EntitiesDTO.Account;

public class AccountGetDto
{
    public int AccountId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool Status { get; set; }

    public int RoleId { get; set; }
    public virtual RoleGetDto Role { get; set; }
    public virtual ICollection<ExpenseGetDto> Expenses { get; set; }
    public virtual ICollection<InvoiceGetDto> Invoices { get; set; }
}