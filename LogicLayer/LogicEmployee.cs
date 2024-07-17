using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;

namespace LogicLayer
{
    public class LogicEmployee
    {
        public static List<EntityEmployee> LLEmployeeList()
        {
            return DALEmployee.EmployeeList();
        }
        public static int LLEmployeeAdd(EntityEmployee emp)
        {
            if(emp.Ad != null && emp.Ad.Length >= 3 && emp.Soyad != null && emp.Soyad.Length >= 3 && emp.Sehir != null && emp.Sehir.Length >= 3 && emp.Gorev != null && emp.Gorev.Length >= 3 && emp.Maas > 0)
            {
                return DALEmployee.AddEmployee(emp);
            }
            else
            {
               return -1;
            }   
        }

        public static bool LLEmployeeDelete(int emp)
        {
            if(emp > 0)
            {
                return DALEmployee.DeleteEmployee(emp);
            }
            else
            {
                return false;
            }
        }

        public static bool LLEmployeUpdate(EntityEmployee emp)
        {
            if (emp.Ad != null && emp.Ad.Length >= 3 && emp.Soyad != null && emp.Soyad.Length >= 3 && emp.Sehir != null && emp.Sehir.Length >= 3 && emp.Gorev != null && emp.Gorev.Length >= 3 && emp.Maas > 0 && emp.Id > 0)
            {
                return DALEmployee.UpdateEmployee(emp);
            }
            else
            {
                return false;
            }
        }
    }
}
