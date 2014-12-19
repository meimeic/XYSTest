using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace XYS.His
{
   public abstract class Patient
    {
       public Patient()
       {
       }
       static class PatientModel : PersonModel
       {
           private string _pid;

       }
       public bool update()
       {
           return true;
       }
       public PatientModel getPatient(string pid)
       {
       }
       protected void checkPatient()
       {
 
       }
    }
}
