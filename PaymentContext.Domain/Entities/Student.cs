using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace  PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;
        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name {get; private set;}
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions {get {return _subscriptions.ToArray();}}

        public void AddSubscrisption(Subscription subscription){
            var hasSubscritpionActive = false;
            foreach(var sub in _subscriptions)
            {
                if(sub.Active)
                    hasSubscritpionActive = true;
            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscritpionActive, "Student.Subscriptions", "Você já tem uma assinatura ativa.")
                .IsTrue(subscription.Payments.Any(), "Student.Subscription.Payments", "Esta assinatura não possui pagamentos.")
            );         
            
            
            // if(Valid)
                _subscriptions.Add(subscription);

        }
    }    
    
}