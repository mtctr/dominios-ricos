using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymenContext.Domain.Commands
{
    public class CreatePayPalSubscriptionCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Address { get; set; }
        public string TransactionCode { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string PayerEmail { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                 .Requires()
                 .HasMinLen(FirstName, 3, "FirstName", "Nome deve conter pelo menos 3 caracteres")
                 .HasMinLen(LastName, 3, "LastName", "Sobrenome deve conter pelo menos 3 caracteres")
                 .HasMaxLen(FirstName, 40, "FirstName", "Nome deve conter pelo  no máximo 40 caracteres")
             );
        }
    }
}