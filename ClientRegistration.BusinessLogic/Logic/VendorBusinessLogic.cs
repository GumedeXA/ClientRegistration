using System.Collections.Generic;
using ClientRegistration.BusinessLogic.Interfaces;
using ClientRegistration.Data.Entities;
using ClientRegistration.ViewModels.ViewModels;
using ClientRegistration.Repository.Repository;
using System.Linq;

namespace ClientRegistration.BusinessLogic.Logic
{
    public class VendorBusinessLogic : IVendorBusinessLogic
    {
        public static Vendor ConvertToVendor(RegisterViewModel model)
        {
            var vendor = new Vendor
            {
                vendorId = model.Id,
                VendorEmail = model.VendorEmail,
                RegistrationDate = model.RegistrationDate,
                TelephoneNumber = model.TelephoneNumber,
                VendorPostalAddress = model.VendorPostalAddress,
                VendorRegNo = model.VendorRegNo,
                VendorName = model.VendorName,
                Other=model.Other,   
                
            };
            return vendor;
        }

        public void Insert(RegisterViewModel model)
        {
            using (var db = new VendorRepository())
            {
                db.Insert(ConvertToVendor(model));
            }
        }

        public void Delete(RegisterViewModel model)
        {
            using (var db=new VendorRepository())
            {
                db.Delete(ConvertToVendor(model));
            }
        }

        public IEnumerable<VendorViewModel> GetAllVendorsByBusinessAdmin(string BusinessAdminId)
        {
            using (var db = new VendorRepository())
            {
                return db.GetAll().Select(model => new VendorViewModel
                {
                    vendorId = model.vendorId,
                    VendorEmail = model.VendorEmail,
                    RegistrationDate = model.RegistrationDate,
                    TelephoneNumber = model.TelephoneNumber,
                    VendorPostalAddress = model.VendorPostalAddress,
                    VendorRegNo = model.VendorRegNo,
                    VendorName = model.VendorName,
                }).Where(x => x.BusAdminId.Equals(BusinessAdminId));
            }
        }

        public VendorViewModel GetById(int VendorId)
        {
            using (var db = new VendorRepository())
            {
                var vendordbRes = db.GetAll().ToList().Find(d => (d.vendorId.Equals(VendorId)));

                var vendorview = new VendorViewModel();
                {
                    vendorview.vendorId = vendordbRes.vendorId;
                    vendorview.VendorEmail = vendordbRes.VendorEmail;
                    vendorview.RegistrationDate = vendordbRes.RegistrationDate;
                    vendorview.TelephoneNumber = vendordbRes.TelephoneNumber;
                    vendorview.VendorPostalAddress = vendordbRes.VendorPostalAddress;
                    vendorview.VendorRegNo = vendordbRes.VendorRegNo;
                    vendorview.VendorName = vendordbRes.VendorName;
                }
                return vendorview;

            }
        }

        public void Update(RegisterViewModel model)
        {
            using (var db=new VendorRepository())
            {
                db.Update(ConvertToVendor(model));
            }
        }
    }
}
