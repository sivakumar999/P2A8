using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDb
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AdvancedDbEntities())
            {
                while (true)
                {
                    Console.WriteLine("Select a table:");
                    Console.WriteLine("1. Employees");
                    Console.WriteLine("2. Products");
                    Console.WriteLine("3. Orders");
                    Console.WriteLine("4. Exit");

                    int tableChoice;
                    if (int.TryParse(Console.ReadLine(), out tableChoice))
                    {
                        switch (tableChoice)
                        {
                            case 1:
                                PerformEmployeeOperations(context);
                                break;
                            case 2:
                                PerformProductOperations(context);
                                break;
                            case 3:
                                PerformOrderOperations(context);
                                break;
                            case 4:
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }
            }
        }

        // Employee CRUD operations
        static void PerformEmployeeOperations(AdvancedDbEntities context)
        {
            while (true)
            {
                Console.WriteLine("Employee Operations:");
                Console.WriteLine("1. Create Employee");
                Console.WriteLine("2. Read Employee");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Back to Table Selection");

                int operationChoice;
                if (int.TryParse(Console.ReadLine(), out operationChoice))
                {
                    switch (operationChoice)
                    {
                        case 1:
                            CreateEmployee(context);
                            break;
                        case 2:
                            ReadEmployee(context);
                            break;
                        case 3:
                            UpdateEmployee(context);
                            break;
                        case 4:
                            DeleteEmployee(context);
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        // Product CRUD operations
        static void PerformProductOperations(AdvancedDbEntities context)
        {
            while (true)
            {
                Console.WriteLine("Product Operations:");
                Console.WriteLine("1. Create Product");
                Console.WriteLine("2. Read Product");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Back to Table Selection");

                int operationChoice;
                if (int.TryParse(Console.ReadLine(), out operationChoice))
                {
                    switch (operationChoice)
                    {
                        case 1:
                            CreateProduct(context);
                            break;
                        case 2:
                            ReadProduct(context);
                            break;
                        case 3:
                            UpdateProduct(context);
                            break;
                        case 4:
                            DeleteProduct(context);
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        // Order CRUD operations
        static void PerformOrderOperations(AdvancedDbEntities context)
        {
            while (true)
            {
                Console.WriteLine("Order Operations:");
                Console.WriteLine("1. Create Order");
                Console.WriteLine("2. Read Order");
                Console.WriteLine("3. Update Order");
                Console.WriteLine("4. Delete Order");
                Console.WriteLine("5. Back to Table Selection");

                int operationChoice;
                if (int.TryParse(Console.ReadLine(), out operationChoice))
                {
                    switch (operationChoice)
                    {
                        case 1:
                            CreateOrder(context);
                            break;
                        case 2:
                            ReadOrder(context);
                            break;
                        case 3:
                            UpdateOrder(context);
                            break;
                        case 4:
                            DeleteOrder(context);
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        // Employee CRUD methods
        static void CreateEmployee(AdvancedDbEntities context)
        {
            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Birth Date (yyyy-MM-dd):");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
            {
                var newEmployee = new Employee
                {
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = birthDate
                };
                context.Employees.Add(newEmployee);
                context.SaveChanges();
                Console.WriteLine("Employee created successfully.");
            }
            else
            {
                Console.WriteLine("Invalid date format. Employee not created.");
            }
        }

        static void ReadEmployee(AdvancedDbEntities context)
        {
            Console.WriteLine("Enter Employee ID to read:");
            if (int.TryParse(Console.ReadLine(), out int employeeId))
            {
                var employee = context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
                if (employee != null)
                {
                    Console.WriteLine($"Employee ID: {employee.EmployeeId}");
                    Console.WriteLine($"First Name: {employee.FirstName}");
                    Console.WriteLine($"Last Name: {employee.LastName}");
                    //Console.WriteLine($“BirthDate: { employee.BirthDate:yyyy - MM - dd}”);

                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Employee ID.");
            }
        }

        static void UpdateEmployee(AdvancedDbEntities context)
        {
            Console.WriteLine("Enter Employee ID to update:");
            if (int.TryParse(Console.ReadLine(), out int employeeId))
            {
                var employee = context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
                if (employee != null)
                {
                    Console.WriteLine("Enter new First Name:");
                    string newFirstName = Console.ReadLine();
                    Console.WriteLine("Enter new Last Name:");
                    string newLastName = Console.ReadLine();
                    Console.WriteLine("Enter new Birth Date (yyyy-MM-dd):");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime newBirthDate))
                    {
                        employee.FirstName = newFirstName;
                        employee.LastName = newLastName;
                        employee.BirthDate = newBirthDate;
                        context.SaveChanges();
                        Console.WriteLine("Employee updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Employee not updated.");
                    }
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Employee ID.");
            }
        }

        static void DeleteEmployee(AdvancedDbEntities context)
        {
            Console.WriteLine("Enter Employee ID to delete:");
            if (int.TryParse(Console.ReadLine(), out int employeeId))
            {
                var employee = context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
                if (employee != null)
                {
                    context.Employees.Remove(employee);
                    context.SaveChanges();
                    Console.WriteLine("Employee deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Employee ID.");
            }
        }

        // Product CRUD methods
        static void CreateProduct(AdvancedDbEntities context)
        {
            Console.WriteLine("Enter Product Name:");
            string productName = Console.ReadLine();
            Console.WriteLine("Enter Description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter Price:");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                var newProduct = new Product
                {
                    ProductName = productName,
                    Description = description,
                    Price = price
                };
                context.Products.Add(newProduct);
                context.SaveChanges();
                Console.WriteLine("Product created successfully.");
            }
            else
            {
                Console.WriteLine("Invalid price format. Product not created.");
            }
        }

        static void ReadProduct(AdvancedDbEntities context)
        {
            Console.WriteLine("Enter Product ID to read:");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                var product = context.Products.FirstOrDefault(p => p.ProductId == productId);
                if (product != null)
                {
                    Console.WriteLine($"Product ID: {product.ProductId}");
                    Console.WriteLine($"Product Name: {product.ProductName}");
                    Console.WriteLine($"Description: {product.Description}");
                    Console.WriteLine($"Price: {product.Price:C}");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Product ID.");
            }
        }

        static void UpdateProduct(AdvancedDbEntities context)
        {
            Console.WriteLine("Enter Product ID to update:");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                var product = context.Products.FirstOrDefault(p => p.ProductId == productId);
                if (product != null)
                {
                    Console.WriteLine("Enter new Product Name:");
                    string newProductName = Console.ReadLine();
                    Console.WriteLine("Enter new Description:");
                    string newDescription = Console.ReadLine();
                    Console.WriteLine("Enter new Price:");
                    if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
                    {
                        product.ProductName = newProductName;
                        product.Description = newDescription;
                        product.Price = newPrice;
                        context.SaveChanges();
                        Console.WriteLine("Product updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid price format. Product not updated.");
                    }
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Product ID.");
            }
        }

        static void DeleteProduct(AdvancedDbEntities context)
        {
            Console.WriteLine("Enter Product ID to delete:");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                var product = context.Products.FirstOrDefault(p => p.ProductId == productId);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                    Console.WriteLine("Product deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Product ID.");
            }
        }

        // Order CRUD methods
        static void CreateOrder(AdvancedDbEntities context)
        {
            Console.WriteLine("Enter Order Date (yyyy-MM-dd HH:mm:ss):");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime orderDate))
            {
                Console.WriteLine("Enter Quantity:");
                if (short.TryParse(Console.ReadLine(), out short quantity))
                {
                    Console.WriteLine("Enter Discount (0-1):");
                    if (float.TryParse(Console.ReadLine(), out float discount) && discount >= 0 && discount <= 1)
                    {
                        Console.WriteLine("Is Shipped (true/false):");
                        if (bool.TryParse(Console.ReadLine(), out bool isShipped))
                        {
                            var newOrder = new Order
                            {
                                OrderDate = orderDate,
                                Quantity = quantity,
                                Discount = discount,
                                IsShipped = isShipped
                            };
                            context.Orders.Add(newOrder);
                            context.SaveChanges();
                            Console.WriteLine("Order created successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Is Shipped value. Order not created.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid discount value. Order not created.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid quantity format. Order not created.");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format. Order not created.");
            }
        }

        static void ReadOrder(AdvancedDbEntities context)
        {
            Console.WriteLine("Enter Order ID to read:");
            if (int.TryParse(Console.ReadLine(), out int orderId))
            {
                var order = context.Orders.FirstOrDefault(o => o.OrderId == orderId);
                if (order != null)
                {
                    Console.WriteLine($"Order ID: {order.OrderId}");
                    Console.WriteLine($"Order Date: {order.OrderDate}");
                    Console.WriteLine($"Quantity: {order.Quantity}");
                    Console.WriteLine($"Discount: {order.Discount:P}");
                    Console.WriteLine($"Is Shipped: {order.IsShipped}");
                }
                else
                {
                    Console.WriteLine("Order not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Order ID.");
            }
        }

        static void UpdateOrder(AdvancedDbEntities context)
        {
            Console.WriteLine("Enter Order ID to update:");
            if (int.TryParse(Console.ReadLine(), out int orderId))
            {
                var order = context.Orders.FirstOrDefault(o => o.OrderId == orderId);
                if (order != null)
                {
                    Console.WriteLine("Enter new Order Date (yyyy-MM-dd HH:mm:ss):");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime newOrderDate))
                    {
                        Console.WriteLine("Enter new Quantity:");
                        if (short.TryParse(Console.ReadLine(), out short newQuantity))
                        {
                            Console.WriteLine("Enter new Discount (0-1):");
                            if (float.TryParse(Console.ReadLine(), out float newDiscount) && newDiscount >= 0 && newDiscount <= 1)
                            {
                                Console.WriteLine("Is Shipped (true/false):");
                                if (bool.TryParse(Console.ReadLine(), out bool newIsShipped))
                                {
                                    order.OrderDate = newOrderDate;
                                    order.Quantity = newQuantity;
                                    order.Discount = newDiscount;
                                    order.IsShipped = newIsShipped;
                                    context.SaveChanges();
                                    Console.WriteLine("Order updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Is Shipped value. Order not updated.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid discount value. Order not updated.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid quantity format. Order not updated.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Order not updated.");
                    }
                }
                else
                {
                    Console.WriteLine("Order not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Order ID.");
            }
        }

        static void DeleteOrder(AdvancedDbEntities context)
        {
            Console.WriteLine("Enter Order ID to delete:");
            if (int.TryParse(Console.ReadLine(), out int orderId))
            {
                var order = context.Orders.FirstOrDefault(o => o.OrderId == orderId);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                    Console.WriteLine("Order deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Order not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Order ID.");
            }
        }
    }
}
