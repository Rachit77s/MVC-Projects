Select * from Users
Select * from UserRoles
Select * from Roles
Select * from CartItems
Select * from Carts
Select * from Categories
Select * from OrderItems
Select * from Orders
Select * from Products
Select * from Transactions


sp_rename 'TableName.OldColumnName', 'New ColumnName', 'COLUMN';

--Write a query to rename the column name “BID” to “BooksID”.
sp_rename 'Books.BID', 'BooksID', 'COLUMN';

sp_rename 'Users.UpdatedDate', 'UpdateDate', 'COLUMN';
sp_rename 'Roles.UpdatedDate', 'UpdateDate', 'COLUMN';
sp_rename 'Users.UpdatedDate', 'UpdateDate', 'COLUMN';
sp_rename 'Carts.UpdatedDate', 'UpdateDate', 'COLUMN';
sp_rename 'Categories.UpdatedDate', 'UpdateDate', 'COLUMN';
sp_rename 'Orders.UpdatedDate', 'UpdateDate', 'COLUMN';
sp_rename 'Products.UpdatedDate', 'UpdateDate', 'COLUMN';
sp_rename 'Transactions.UpdatedDate', 'UpdateDate', 'COLUMN';