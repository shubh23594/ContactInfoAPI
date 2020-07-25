# ContactInfoAPI
ContactInfoAPI having Add, Update, Delete, GetAll and Get Details on the basis of ID. All data stored in Azure MySQL server.
It will return response in follwoing manner:-
[
      {
      "contactId": 1,
      "firstName": "XXX",
      "lastName": "XXX",
      "email": "XXX@gmail.com",
      "phoneNumber": "XXXX",
      "statusDetails": "Active"
   },
   {
      "contactId": 2,
      "firstName": "XXX",
      "lastName": "XXX",
      "email": "XXX@gmail.com",
      "phoneNumber": "XXXX",
      "statusDetails": "Active"
   }
]

1) getAllContact -> Post  : It will return all the records which present in Azure SQL Database
2) addContact  -> Post  : It will add Contact details by passing contact details object
3) updateContact -> Put  : It will Update contact one by one by passing ID and contact details information which need to be updated
4) deleteContact -> Delete : It will Delete the contact details by passing ID
5) getContact -> Get : It will get Contact details by passing ID.

All above operation will be operating through net core with Azure SQL Database.
Following functionality/Net Core Feature added:-
- Dependacy Injection
- Exception Handling 
- Different Status Code on the basis of Response
