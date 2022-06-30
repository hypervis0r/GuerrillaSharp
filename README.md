# GuerrillaSharp
C# Library for the GuerrillaMail API

https://www.nuget.org/packages/Hypervis0r.GuerrillaSharp/

## Usage

```cs

GuerrillaMail mail = new GuerrillaMail();

await mail.GetEmailAddress(); // Initializes mailbox

await mail.CheckEmail(); // Checks mailbox for email

await mail.FetchEmail(emailId); // Gets specific email

```
