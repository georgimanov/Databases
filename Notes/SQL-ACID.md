ACID
-Automacity
-Consistency
-Isolation
-Durability


ACID
Atomicity 
- transactions execute as a whole
- DBMS to guarantee that either all of the operations are performed or none of them

Consistency
- the database is in legal state when the transaction begins and when it ends
- only valid data will be written in the DBMS
- transactions cannot break the rules of the database, e.g. integrity constraints
	- primary keys, foreign keys, alternate keys 

Isolation
- multiple transactions running at the same time do not impact each other's execution
- transactions don't see other transaction's uncommitted changes
- Isolation level defines how deep transaction isolate from one another

Durability
- if a transaction is committed it becomes persistent
	- cannot be lost or undone
- ensured by use of database transaction logs

