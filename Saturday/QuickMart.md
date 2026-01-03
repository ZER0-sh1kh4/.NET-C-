# Day-08(Saturday) .NET(C#)

### Problem Statemnet

```csharp
class SalesTransaction
{
    public string InvoiceNo;
    public string CustomerName;
    public string ItemName;
    public int Quantity;
    public decimal PurchaseAmount;
    public decimal SellingAmount;
    public string ProfitOrLossStatus;
    public decimal ProfitOrLossAmount;
    public decimal ProfitMarginPercent;
}

class Program
{
    static SalesTransaction LastTransaction;
    static bool HasLastTransaction = false;

    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("================== QuickMart Traders ==================");
            Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
            Console.WriteLine("2. View Last Transaction");
            Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CreateTransaction();
                    break;

                case 2:
                    ViewTransaction();
                    break;

                case 3:
                    CalculateProfitLoss();
                    break;

                case 4:
                    Console.WriteLine("Thank you. Application closed normally.");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void CreateTransaction()
    {
        SalesTransaction tx = new SalesTransaction();

        Console.Write("Enter Invoice No: ");
        tx.InvoiceNo = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(tx.InvoiceNo))
        {
            Console.WriteLine("Invoice number cannot be empty.");
            return;
        }

        Console.Write("Enter Customer Name: ");
        tx.CustomerName = Console.ReadLine();

        Console.Write("Enter Item Name: ");
        tx.ItemName = Console.ReadLine();

        Console.Write("Enter Quantity: ");
        tx.Quantity = Convert.ToInt32(Console.ReadLine());
        if (tx.Quantity <= 0)
        {
            Console.WriteLine("Quantity must be greater than 0.");
            return;
        }

        Console.Write("Enter Purchase Amount (total): ");
        tx.PurchaseAmount = Convert.ToDecimal(Console.ReadLine());
        if (tx.PurchaseAmount <= 0)
        {
            Console.WriteLine("Purchase amount must be greater than 0.");
            return;
        }

        Console.Write("Enter Selling Amount (total): ");
        tx.SellingAmount = Convert.ToDecimal(Console.ReadLine());
        if (tx.SellingAmount < 0)
        {
            Console.WriteLine("Selling amount cannot be negative.");
            return;
        }

        ComputeProfitLoss(tx);

        LastTransaction = tx;
        HasLastTransaction = true;

        Console.WriteLine("Transaction saved successfully.");
        PrintCalculation(tx);
    }

    static void ViewTransaction()
    {
        if (!HasLastTransaction)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }

        Console.WriteLine("-------------- Last Transaction --------------");
        Console.WriteLine("InvoiceNo: " + LastTransaction.InvoiceNo);
        Console.WriteLine("Customer: " + LastTransaction.CustomerName);
        Console.WriteLine("Item: " + LastTransaction.ItemName);
        Console.WriteLine("Quantity: " + LastTransaction.Quantity);
        Console.WriteLine("Purchase Amount: " + LastTransaction.PurchaseAmount.ToString("0.00"));
        Console.WriteLine("Selling Amount: " + LastTransaction.SellingAmount.ToString("0.00"));
        Console.WriteLine("Status: " + LastTransaction.ProfitOrLossStatus);
        Console.WriteLine("Profit/Loss Amount: " + LastTransaction.ProfitOrLossAmount.ToString("0.00"));
        Console.WriteLine("Profit Margin: " + LastTransaction.ProfitMarginPercent.ToString("0.00"));
    }

    static void CalculateProfitLoss()
    {
        if (!HasLastTransaction)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }

        ComputeProfitLoss(LastTransaction);
        PrintCalculation(LastTransaction);
    }

    static void ComputeProfitLoss(SalesTransaction tx)
    {
        if (tx.SellingAmount > tx.PurchaseAmount)
        {
            tx.ProfitOrLossStatus = "PROFIT";
            tx.ProfitOrLossAmount = tx.SellingAmount - tx.PurchaseAmount;
        }
        else if (tx.SellingAmount < tx.PurchaseAmount)
        {
            tx.ProfitOrLossStatus = "LOSS";
            tx.ProfitOrLossAmount = tx.PurchaseAmount - tx.SellingAmount;
        }
        else
        {
            tx.ProfitOrLossStatus = "BREAK-EVEN";
            tx.ProfitOrLossAmount = 0;
        }

        tx.ProfitMarginPercent =
            (tx.ProfitOrLossAmount /tx.PurchaseAmount) * 100;
    }

    static void PrintCalculation(SalesTransaction tx)
    {
        Console.WriteLine("Status:" + tx.ProfitOrLossStatus);
        Console.WriteLine("Profit/Loss Amount: " + tx.ProfitOrLossAmount.ToString("0.00"));
        Console.WriteLine("Profit Margin:" + tx.ProfitMarginPercent.ToString("0.00"));
    }
}
```
