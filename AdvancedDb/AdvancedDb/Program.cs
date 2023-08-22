using AdvancedDb;
using System;
using System.Linq;

namespace EFUsingCRUDAssignment8
{
    internal class Program
    {
        static AdvancedDbEntities db;
        static Employee emps;
        static Product prds;
        static Order ords;
        static void Main(string[] args)
        {
            db = new AdvancedDbEntities();
            bool again = true;
            while (again)
            {
                Console.WriteLine("Choose a table:");
                Console.WriteLine("1. Employee");
                Console.WriteLine("2. Product");
                Console.WriteLine("3. Order");
                Console.WriteLine("4. Exit");

                int tableChoice = int.Parse(Console.ReadLine());
                switch (tableChoice)
                {
                    case 1:
                        PerformEmployeeOperations();
                        break;
                    case 2:
                        PerformProductOperations();
                        break;
                    case 3:
                        PerformOrderOperations();
                        break;
                    case 4:
                        again = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        static void PerformEmployeeOperations()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("Employee Operations:");
                Console.WriteLine("1. Create Employee");
                Console.WriteLine("2. Update Employee");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4. To See All Employees");
                Console.WriteLine("5. Back to Table Selection");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreateEmployee();
                        break;
                    case 2:
                        UpdateEmp();
                        break;
                    case 3:
                        DeleteEmp();
                        break;
                    case 4:
                        Toseeallemployees();
                        break;
                    case 5:
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        static void CreateEmployee()
        {
            try
            {
                Employee emp = new Employee();
                Console.WriteLine("Enter Employee ID ");
                emp.EmployeeId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Employee First Name");
                emp.FirstName = Console.ReadLine();
                Console.WriteLine("Enter Employee Last Name");
                emp.LastName = Console.ReadLine();
                Console.WriteLine("Enter Employee Date of Birth ");
                emp.BirthDate = DateTime.Parse(Console.ReadLine());
                db.Employees.Add(emp);
                db.SaveChanges();
                Console.WriteLine("Employee Record Inserted");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
            }
        }

        static void UpdateEmp()
        {
            try
            {
                Console.WriteLine("Enter ID to update details");
                int id = int.Parse(Console.ReadLine());
                emps = db.Employees.SingleOrDefault(e => e.EmployeeId == id);
                if (emps == null)
                {
                    Console.WriteLine("No record with Id: " + id + " exists in the database");
                }
                else
                {
                    Console.WriteLine("Enter Employee First Name");
                    emps.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter Employee Last Name");
                    emps.LastName = Console.ReadLine();
                    Console.WriteLine("Enter Employee Date of Birth ");
                    emps.BirthDate = DateTime.Parse(Console.ReadLine());
                    db.SaveChanges();
                    Console.WriteLine("Employee Record Updated");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
            }
        }

        static void DeleteEmp()
        {
            try
            {
                Console.WriteLine("Enter ID to delete the record");
                int id = int.Parse(Console.ReadLine());
                emps = db.Employees.SingleOrDefault(e => e.EmployeeId == id);
                if (emps == null)
                {
                    Console.WriteLine("No record with Id: " + id + " exists in the database");
                }
                else
                {
                    db.Employees.Remove(emps);
                    db.SaveChanges();
                    Console.WriteLine("Employee Record Deleted");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
            }
        }

        static void Toseeallemployees()
        {
            try
            {
                foreach (Employee e in db.Employees)
                {
                    Console.WriteLine("Employee ID: " + e.EmployeeId);
                    Console.WriteLine("Employee First Name: " + e.FirstName);
                    Console.WriteLine("Employee Last Name: " + e.LastName);
                    Console.WriteLine("Employee Birth Date: " + e.BirthDate);
                 
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
            }
        }

        // Define methods for UpdateEmployee, DeleteEmployee, and DisplayEmployeeDetails as you did before...

        static void PerformProductOperations()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("Product Operations:");
                Console.WriteLine("1. Create Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. To See Product Details");
                Console.WriteLine("5. Back to Table Selection");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreateProduct();
                        break;
                    case 2:
                        UpdateProduct();
                        break;
                    case 3:
                        DeleteProduct();
                        break;
                    case 4:
                        ListALLProducts();
                        break;
                    case 5:
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        static void CreateProduct()
        {
            try
            {
                Product prd = new Product();
                Console.WriteLine("Enter Product ID ");
                prd.ProductId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Product Name");
                prd.ProductName = Console.ReadLine();
                Console.WriteLine("Enter Product Description");
                prd.Description = Console.ReadLine();
                Console.WriteLine("Enter Product Release Date ");
                prd.ReleaseDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter Product Price");
                prd.Price = decimal.Parse(Console.ReadLine());
                db.Products.Add(prd);
                db.SaveChanges();
                Console.WriteLine("Product Record Created Successfully");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
            }
        }
        static void UpdateProduct()
        {
            try
            {
                Console.WriteLine("Enter ID to update details");
                int id = int.Parse(Console.ReadLine());
                prds = db.Products.SingleOrDefault(p => p.ProductId == id);
                if (prds == null)
                {
                    Console.WriteLine("No record with Id: " + id + " exists in the database");
                }
                else
                {
                    Console.WriteLine("Enter Product Name");
                    prds.ProductName = Console.ReadLine();
                    Console.WriteLine("Enter Product Description");
                    prds.Description = Console.ReadLine();
                    Console.WriteLine("Enter Product Price ");
                    prds.Price = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Product Release Date ");
                    prds.ReleaseDate = DateTime.Parse(Console.ReadLine());
                    db.SaveChanges();
                    Console.WriteLine("Product Record Updated Successfully");
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
            }
        }

        static void DeleteProduct()
        {
            try
            {
                Console.WriteLine("Enter ID to delete the record");
                int id = int.Parse(Console.ReadLine());
                prds = db.Products.SingleOrDefault(p => p.ProductId == id);
                if (prds == null)
                {
                    Console.WriteLine("No record with Id: " + id + " exists in the database");
                }
                else
                {
                    db.Products.Remove(prds);
                    db.SaveChanges();
                    Console.WriteLine("Product Record Deleted Successfully");
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
            }
        }

        static void ListALLProducts()
        {
            try
            {
                foreach (Product p in db.Products)
                {
                    Console.WriteLine("Product ID: " + p.ProductId);
                    Console.WriteLine("Product Name: " + p.ProductName);
                    Console.WriteLine("Product Description: " + p.Description);
                    Console.WriteLine("Product Release Date: " + p.ReleaseDate);
                    Console.WriteLine("Product Price: " + p.Price);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
            }
        }

        // Define methods for UpdateProduct, DeleteProduct, and DisplayProductDetails as you did before...

        static void PerformOrderOperations()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("Order Operations:");
                Console.WriteLine("1. Create Order");
                Console.WriteLine("2. Update Order");
                Console.WriteLine("3. Delete Order");
                Console.WriteLine("4. To See Order Details");
                Console.WriteLine("5. Back to Table Selection");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        InsertOrder();
                        break;
                    case 2:
                        UpdateOrder();
                        break;
                    case 3:
                        DeleteOrder();
                        break;
                    case 4:
                        ListALLOrderDs();
                        break;
                    case 5:
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        static void InsertOrder()
        {
            try
            {
                Order ord = new Order();
                Console.WriteLine("Enter Order ID ");
                ord.OrderId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Order Date");
                ord.OrderDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter Order Quantity");
                ord.Quantity = Int16.Parse(Console.ReadLine());
                Console.WriteLine("Enter Oder Discount");
                ord.Discount = double.Parse(Console.ReadLine());
                Console.WriteLine("Has Order Been Shipped?");
                ord.IsShipped = Boolean.Parse(Console.ReadLine());
                db.Orders.Add(ord);
                db.SaveChanges();
                Console.WriteLine("Order Record created Successfully");
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
            }
        }

        

        static void UpdateOrder()
        {
            try
            {
                Console.WriteLine("Enter ID to update details");
                int id = int.Parse(Console.ReadLine());
                ords = db.Orders.SingleOrDefault(o => o.OrderId == id);
                if (ords == null)
                {
                    Console.WriteLine("No record with Id: " + id + " exists in the database");
                }
                else
                {
                    Console.WriteLine("Enter Order Date");
                    ords.OrderDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Order Quantity");
                    ords.Quantity = Int16.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Order Discount");
                    ords.Discount = double.Parse(Console.ReadLine());
                    Console.WriteLine("Has Order Been Shipped?");
                    ords.IsShipped = bool.Parse(Console.ReadLine());
                    db.SaveChanges();
                    Console.WriteLine("Order Record Updated Successfully");
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
            }
        }

        static void DeleteOrder()
        {
            try
            {
                Console.WriteLine("Enter ID to delete the record");
                int id = int.Parse(Console.ReadLine());
                ords = db.Orders.SingleOrDefault(o => o.OrderId == id);
                if (ords == null)
                {
                    Console.WriteLine("No record with Id: " + id + " exists in the database");
                }
                else
                {
                    db.Orders.Remove(ords);
                    db.SaveChanges();
                    Console.WriteLine("Order Record Deleted Successfully");
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
            }
        }

        static void ListALLOrderDs()
        {
            try
            {
                foreach (Order o in db.Orders)
                {
                    Console.WriteLine("Order ID: " + o.OrderId);
                    Console.WriteLine("Order Date: " + o.OrderDate);
                    Console.WriteLine("Order Quantity: " + o.Quantity);
                    Console.WriteLine("Order Discount: " + o.Discount);
                    Console.WriteLine("the Order shipped? " + o.IsShipped);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!" + ex.Message);
            }
        }

    }
}
