#Day-08 .Net(C#)

###Problem Statment
MediSure Clinic requires a simple console-based billing utility for walk-in patients. The billing desk captures basic patient details and charges, then applies an insurance-based discount rule to compute the final payable amount. The solution must be implemented as a C# Console Application using a clean OOP structure and menu-driven interaction.

```csharp
class PatentBill
{
    public string BillId;
    public string PatentName;
    public bool HasInsurance;
    public decimal ConsultationFee;
    public decimal LabCharges;
    public decimal MedicineCharges;
    public decimal GrossAmount;
    public decimal DiscountAmount;
    public decimal FinalPayable;


}
class Program

{
    static PatentBill LastBill;
    static bool HasLastBill=false;
    public static void Main()
    {
            
        while(true)
        {
            Console.WriteLine("================== MediSure Clinic Billing ==================");
            Console.WriteLine("1. Create New Bill (Enter Patient Details)");
            Console.WriteLine("2. View Last Bill");
            Console.WriteLine("3. Clear Last Bill");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");
            int opt;
            opt=Convert.ToInt32(Console.ReadLine());

            switch(opt){
                case 1:
                CreateBill();
                break;
                case 2:
                ViewBill();
                break;
                case 3:
                ClearBill();
                break;
                case 4:
                Console.WriteLine("Thank you. Application closed normally.");
                return;
                default:
                Console.WriteLine("Invalid option");
                break;

            }
           
        }
        static void CreateBill()
        {
            PatentBill bi=new PatentBill();
            Console.Write("Enter Bill Id: ");
            bi.BillId=Console.ReadLine();
            if(bi.BillId==" ")
            {
                Console.WriteLine("Bill is empty");
                return;
            }
            Console.Write("Enter Patient Name:  ");
            bi.PatentName=Console.ReadLine();

            Console.Write("Is the patient insured? (Y/N): ");
            char insurance=Console.ReadLine().ToUpper()[0];
            bi.HasInsurance=(insurance=='Y');

            Console.Write("Enter Consultation Fee:  ");
            bi.ConsultationFee=Convert.ToDecimal(Console.ReadLine());
            if (bi.ConsultationFee < 0)
            {
                Console.WriteLine("cant be negative");
                return;
            }
            Console.Write("Enter Lab Charges:  ");
            bi.LabCharges=Convert.ToDecimal(Console.ReadLine());
            if (bi.LabCharges <= 0)
            {
                Console.WriteLine("LAB CHARGES cant be 0 or less");
                return;
            }
            Console.Write("Enter Medicine Charges:  ");
            bi.MedicineCharges=Convert.ToDecimal(Console.ReadLine());
            if (bi.MedicineCharges <= 0)
            {
               Console.WriteLine("medicine CHARGES cant be 0 or less");
                return; 
            }
            bi.GrossAmount=bi.ConsultationFee+bi.LabCharges+bi.MedicineCharges;
            if (bi.HasInsurance)
            {
                bi.DiscountAmount=bi.GrossAmount*0.10m;
            }
            else
            {
                bi.DiscountAmount=0;
            }
            bi.FinalPayable=bi.GrossAmount-bi.DiscountAmount;
            LastBill=bi;
            HasLastBill=true;

            Console.WriteLine("Bill created successfully.");
            Console.WriteLine("Gross amount: "+bi.GrossAmount.ToString("0.00"));
            Console.WriteLine("Discount amount: "+bi.DiscountAmount.ToString("0.00"));
            Console.WriteLine("Final payable maount: "+bi.FinalPayable.ToString("0.00"));

        }
        static void ViewBill()
        {
            if (!HasLastBill)
            {
                Console.WriteLine("No bill available. Please create a new bill first.");
            }
            else
            {
                Console.WriteLine("----------- Last Bill -----------");
                Console.WriteLine("BillId: "+LastBill.BillId);
                Console.WriteLine("Patient: "+LastBill.PatentName);
                Console.WriteLine("Insured: "+LastBill.HasInsurance);
                Console.WriteLine("Consultation fee: "+LastBill.ConsultationFee);
                Console.WriteLine("Lab Charges: "+LastBill.LabCharges);
                Console.WriteLine("Medicine charges: "+LastBill.MedicineCharges);
                Console.WriteLine("Gross Amount: "+LastBill.GrossAmount);
                Console.WriteLine("Discount amount: "+LastBill.DiscountAmount);
                Console.WriteLine("Final Payment: "+LastBill.FinalPayable);
            }

        }
        static void ClearBill()
        {
            LastBill=null;
            HasLastBill=false;
            Console.WriteLine("Last bill cleared.");
        }
    }
}
```
