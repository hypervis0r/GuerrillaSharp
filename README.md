# GuerrillaSharp
C# Library for the GuerrillaMail API

https://www.nuget.org/packages/Hypervis0r.GuerrillaSharp/

## Usage

```cs

GuerrillaMail mail = new GuerrillaMail();

mail.GetEmailAddress(); // Initializes mailbox

mail.CheckEmail(); // Checks mailbox for email

mail.FetchEmail(emailId); // Gets specific email

```
