# Address Book
This stores the contact information.
We will be able to create/update/delete the contact information.
There are ten records in the database.

## Technology Used
* .NET Core Web API
* Vue js with typescript
* LiteDB

## Setup

Set up the API 
After we download the folder. <br />
Go to that folder in the command line or  <br />
use VS Code to open the folder and press (ctrl + ~) to open the terminal.  <br />
Please make you are on folder that you just downloaded.<br />
Use the following command.

```csharp
cd AddressBook
dotnet restore
dev-certs https --clean
dev-certs https --trust
dotnet run
```
This will run the web api on the port https://localhost:5001/

Set up the UI
Please make you are on folder that you just downloaded.
Use the following command.

```bash
cd addressbook-ui
npm install
npm run-script serve
```
This will run the UI.
