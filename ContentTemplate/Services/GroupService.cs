using System;
using System.Collections.Generic;
using System.Linq;

namespace ContentTemplate.Services
{
    internal class GroupService
    {
      
        

        public void AddGroup(string name)
        {
            try
            {
                DB.MyContext myContext = new DB.MyContext();

                if(myContext.Groups.Any(x=>x.Name == name))
                {
                    throw new Exception("Такая  группа уже есть  в  бд");
                }
                else
                {
                    myContext.Groups.Add(new DB.Group() { Name = name });
                    myContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DB.Group> Groups ()
        {
            try
            {
                DB.MyContext myContext = new DB.MyContext();
                return myContext.Groups.ToList(); 
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}