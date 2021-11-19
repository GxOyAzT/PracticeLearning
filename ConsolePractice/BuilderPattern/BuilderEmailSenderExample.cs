using System;
using System.Collections.Generic;
using System.Text;

namespace ConsolePractice.BuilderPattern.BuilderEmailSenderExample
{
    public class BuilderEmailSenderExample
    {
        public static void Execute()
        {
            MailService mailService = new MailService();

            mailService.SendEmail(e => e.To("to@x.com").Subject("Subject").Body("Body"));
        }
    }

    public class Email
    {
        public string From, To, Subject, Body;

        protected Email()
        {
        }

        public static EmailBuilder Create()
        {
            return new EmailBuilder(new Email());
        }
    }

    public class EmailBuilder
    {
        protected Email Email { get; set; }

        public EmailBuilder(Email email)
        {
            Email = email;
            email.From = "abx@x.com";
        }

        public EmailBuilder To(string to)
        {
            Email.To = to;
            return this;
        }

        public EmailBuilder Subject(string subject)
        {
            Email.Subject = subject;
            return this;
        }

        public EmailBuilder Body(string body)
        {
            Email.Body = body;
            return this;
        }

        public static implicit operator Email(EmailBuilder emailBuilder)
        {
            return emailBuilder.Email;
        }
    }

    public class MailService
    {
        private void SendEmailInternal(Email email)
        {
            $"From: {email.From}".Write();
            $"To: {email.To}".Write();
            $"Subject: {email.Subject}".Write();
            $"Body: {email.Body}".Write();
        }

        public void SendEmail(Func<EmailBuilder, Email> builder)
        {
            var email = builder(Email.Create());
            SendEmailInternal(email);
        }
    }
}
