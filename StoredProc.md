## QUestion 1
```sql
create procedure sp_uspgetBothValues(@StartDate date, @EndDate date, @AccountId int)
as
begin
select sum(Amount) as TotalDeposit from Transactions where AccountID=@AccountId
and TransactionType='Deposit' and TransactionDate between @StartDate and @EndDate;
select sum(Amount) as TotalWithdrawn from Transactions where AccountID=@AccountId
and TransactionType='Withdraw' and TransactionDate between @StartDate and @EndDate;
end;

EXEC sp_uspgetBothValues '2024-01-01', '2024-01-31', 101;
```

## Question 2
```sql
select AccountID,Month(TransactionDate) as bonusmonth, sum(Amount) as Total from Transactions 
where TransactionType='Deposit' group by AccountID,Month(TransactionDate) 
having Sum(Amount)>50000;

insert into Bonus(BonusID,AccountID,BonusMonth,BonusYear, BonusAmount,CreatedDate)
select ROW_NUMBER() OVER (ORDER BY AccountID), AccountID , Month(TransactionDate), Year(TransactionDate), 1000, GetDate() from Transactions
where TransactionType ='Deposit' group by AccountID , Month(TransactionDate), Year(TransactionDate) 
having sum(Amount) >50000;
```

## Question 3
```sql
Select Customers.CustomerName, Accounts.AccountNumber, Accounts.OpeningBalance +isnull(D.TotalDeposit,0)-isnull(W.TotalWithdraw,0)+isnull(B.Bonus,0) as CurrentBalance
from Customers inner join Accounts on Customers.CustomerID=Accounts.CustomerID
left join (select AccountID , Sum(Amount) as TotalDeposit from Transactions where TransactionType='Deposit' group by  AccountID) as D
on Accounts.AccountID=D.AccountId 
left join (select AccountID , Sum(Amount) as TotalWithdraw from Transactions where TransactionType='Withdraw' group by  AccountID) as W
on Accounts.AccountID=W.AccountId
left join (select AccountID , Sum(BonusAmount) as Bonus from Bonus group by  AccountID) as  B
on Accounts.AccountID=B.AccountId
```
