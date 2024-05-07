using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

using MvcDemo.Data;

namespace MvcDemo.Models
{
    public class RegistrationModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile_no { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Srno { get; set; }

        public string Savereg(RegistrationModel model)
        {
            string  msg = "Save successfully";
            mvcdemoEntities Db = new mvcdemoEntities();
            var reg = Db.tblContacts.Where(m => m.Id ==model.Id).FirstOrDefault();
            if(model.Id==0)
            
            {
                var regData = new tblContact()
                {
                    Id =model.Id,
                    Name = model.Name,
                    Mobile_no = model.Mobile_no,
                    Address = model.Address,
                    City = model.City,
                };

                Db.tblContacts.Add(regData);
                Db.SaveChanges();
              
            }
            else
            {
                reg.Id = model.Id;
                reg.Name = model.Name;
                reg.Mobile_no = model.Mobile_no;
                reg.Address = model.Address;
                reg.City = model.City;

                Db.SaveChanges();
                msg = "Update Successfully";
            };

            return msg;

        }
        

        public List <RegistrationModel> GetRegistrationList()
        {
            
            
            mvcdemoEntities Db = new mvcdemoEntities();
            List<RegistrationModel> lstRegistration = new List<RegistrationModel>();
            var AddRegistrationList = Db.tblContacts.ToList();
            int Srno = 1;
            if(AddRegistrationList !=null)  
            {
                foreach( var registration in AddRegistrationList)
                {
                    lstRegistration.Add(new RegistrationModel()
                    {
                        Srno=Srno,
                        Id = registration.Id,
                        Name = registration.Name,
                        Mobile_no = registration.Mobile_no,
                        Address = registration.Address,
                        City = registration.City,

                     
                    });
                    Srno++;
                }
            }
            return lstRegistration;
        }
        public string DeleteRegistration(int Id)
        {
            var msg = "Delete Successfully";
            mvcdemoEntities Db = new mvcdemoEntities();
            var data = Db.tblContacts.Where(m => m.Id == Id).FirstOrDefault();
            if (data != null)
            {
                Db.tblContacts.Remove(data);
                Db.SaveChanges();
            }
            return msg;
        }
        

        public RegistrationModel GetRegisterbyId(int Id)

        {
            RegistrationModel model = new RegistrationModel();
            mvcdemoEntities Db = new mvcdemoEntities();
            var data = Db.tblContacts.Where(m => m.Id == Id).FirstOrDefault();
            if(data !=null)
            {  
               model. Id = data.Id;
                model.Name = data.Name;
               model. Mobile_no = data.Mobile_no;
               model. Address = data.Address;
                model.City = data.City;

            }
            return model;
        }
    }
}



