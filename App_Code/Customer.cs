using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Phone { get; set; }

    public Customer(int id, string name, string email, string password, int phone)
    {
        ID = id;
        Name = name;
        Email = email;
        Password = password;
        Phone = phone;
    }

    public Customer()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}